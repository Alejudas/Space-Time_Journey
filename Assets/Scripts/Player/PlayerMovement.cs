using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedMove;

    [SerializeField] private Vector2 direction;

    [SerializeField] private Joystick joystick;
    public bool inTrigger;

    protected IInteractable interactables;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        direction = new Vector2(horizontal,vertical).normalized;
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
