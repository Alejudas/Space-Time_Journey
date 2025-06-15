using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Puzzle3 : MonoBehaviour,IInteractable
{
    [SerializeField] UnityEvent EventsOnActive;
    [SerializeField] GameObject PanelActive, router, unlocker;
    [SerializeField] StickDetector stickDetector;
    public void Interact(GameObject player)
    {
        PanelActive.SetActive(true);
    }
    private void Update()
    {
        if (stickDetector.Unlock)
        {
            EventsOnActive.Invoke();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MoveLeft()
    {
        Vector3 currentRotation = router.transform.localEulerAngles;
        router.transform.localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y , currentRotation.z + 45f);
    }
    public void MoveRight()
    {
        Vector3 currentRotation = router.transform.localEulerAngles;
        router.transform.localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, currentRotation.z - 45f);
    }
}
