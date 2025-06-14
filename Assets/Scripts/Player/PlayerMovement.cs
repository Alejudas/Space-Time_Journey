using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedMove;

    [SerializeField] private Vector2 direction;

    [SerializeField] private Joystick joystick;
    public bool inTrigger;

    protected IInteractable interactables;
    private Rigidbody2D rb;

    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        direction = new Vector2(horizontal,vertical).normalized;

        float speed = direction.magnitude;
        animator.SetFloat("Speed", speed);

        // Flip
        if (horizontal < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1); // mirando a la izquierda
        }
        else if (horizontal > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1); // mirando a la derecha
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position +  direction * speedMove * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            interactables = interactable;
            inTrigger = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable) && interactable == interactables)
        {
            interactables = null;


        }
      
    }

    public void PushInteractButton()
    {
        if (interactables != null)
            interactables.Interact(gameObject);
    }

    
}
