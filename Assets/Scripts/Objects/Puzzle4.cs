using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Puzzle4 : MonoBehaviour,IInteractable
{
    [Header("Variables de sistema de botones")]

    [SerializeField] UnityEvent eventOfUseButom;
    [SerializeField] UnityEvent eventOfUseButomRestart;
    [SerializeField] float DistanceOfclick;

    [Header("Variables del puzzle")]

    [SerializeField] Rigidbody2D rigidActive;
    [SerializeField] UnityEvent EventsOnActive;

    [SerializeField] List<UnlockDetector> unlockCorrect;
    [SerializeField] List<UnlockDetector> unlockInCorrect;

    [SerializeField] Transform OriginalPosition;

    [SerializeField] GameObject panelActive;
    [SerializeField] GameObject ObjectRigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        OriginalPosition.position = ObjectRigid.transform.position;
        rigidActive.bodyType = RigidbodyType2D.Kinematic;
    }
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < unlockCorrect.Count; i++)
        {
            if(unlockCorrect[i].Unlock)
            {
                EventsOnActive.Invoke();
            }
        }
        for(int i = 0;i < unlockInCorrect.Count; i++)
        {
            if (unlockInCorrect[i].Unlock)
            {
                eventOfUseButomRestart.Invoke();
                rigidActive.linearVelocity = Vector2.zero;
                rigidActive.angularVelocity = 0f;
                ObjectRigid.transform.position = OriginalPosition.transform.position;
                rigidActive.bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
    public void Interact(GameObject player)
    {
        panelActive.SetActive(true);
    }
    public void MoveLeft()
    {
        Vector3 currentPosition = ObjectRigid.transform.position;
        ObjectRigid.transform.position = new Vector3(currentPosition.x - DistanceOfclick, currentPosition.y, currentPosition.z);
    }
    public void MoveRight()
    {
        Vector3 currentPosition = ObjectRigid.transform.position;
        ObjectRigid.transform.position = new Vector3(currentPosition.x + DistanceOfclick, currentPosition.y, currentPosition.z);
    }
    public void UseButtomActive()
    {
        eventOfUseButom.Invoke();
        rigidActive.bodyType = RigidbodyType2D.Dynamic;
    }
}
