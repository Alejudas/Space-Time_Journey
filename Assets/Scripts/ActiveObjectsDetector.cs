using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveObjectsDetector : MonoBehaviour
{
    [SerializeField] List<GameObject> validadorObj;
    [SerializeField] UnityEvent active;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < validadorObj.Count; i++)
        {
            if (validadorObj[i].activeSelf == false)
            {
                active.Invoke();
            }
        }
    }
}
