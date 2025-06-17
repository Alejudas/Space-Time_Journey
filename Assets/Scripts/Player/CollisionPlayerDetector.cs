using UnityEngine;
using UnityEngine.Events;

public class CollisionPlayerDetector : MonoBehaviour
{
    [SerializeField] UnityEvent EventsOfCollision;
    [SerializeField] UnityEvent EventsOfUnCollision;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
            EventsOfCollision.Invoke();



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
            EventsOfUnCollision.Invoke();
    }
}
