using UnityEngine;

public class Valvulas : MonoBehaviour, IInteractable
{
    [SerializeField] public bool OnActive = false;
    [SerializeField] public Transform destiny;
    [SerializeField] public float speed;
    private void Update()
    {
        if (OnActive)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.rotation, destiny.rotation, speed * Time.deltaTime);
        }
    }
    public void Interact(GameObject player)
    {
        OnActive = true;
       
    }
}
