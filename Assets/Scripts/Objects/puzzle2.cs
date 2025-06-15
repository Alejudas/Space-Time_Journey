using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class puzzle2 : MonoBehaviour
{
    [SerializeField] UnityEvent EventCreate;

    [SerializeField] GameObject puzzlePanel;
    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] TextMeshProUGUI maxValue;

    [SerializeField] int CounterObjects;

    [SerializeField] List<GameObject> ObjectsForActivate;
    private void Start()
    {
        maxValue.text = ObjectsForActivate.Count.ToString();

    }
    private void Update()
    {
        counterText.text = CounterObjects.ToString();
        if (CounterObjects == ObjectsForActivate.Count)
        {
            EventCreate.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        puzzlePanel.SetActive(true);
        for (int i = 0; i < ObjectsForActivate.Count; i++)
        {
            if (collision.gameObject == ObjectsForActivate[i])
            {
                Debug.Log("agrega");
                CounterObjects++;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        puzzlePanel.SetActive(false);
        for (int i = 0; i < ObjectsForActivate.Count; i++)
        {
            if (collision.gameObject == ObjectsForActivate[i])
            {
                Debug.Log("elimina");
                CounterObjects--;
            }
        }
    }
}

