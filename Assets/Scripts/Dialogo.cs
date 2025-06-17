using UnityEngine;
using System.Collections;
using TMPro;

public class Dialogo : MonoBehaviour, IInteractable
{
    private bool isPlayerInRange;
    [SerializeField] private GameObject recursoVisual;
    [SerializeField] private GameObject panelText ;
    [SerializeField] private GameObject panelControles;
    [SerializeField] private GameObject boton;
    [SerializeField] private TMP_Text  dialogue ;
    [SerializeField, TextArea(4,3)] private string[] mensaje;
    private bool dialogueStart;
    private int lineIndex;
    public float timeCharacters = 0.05f;

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Interact(GameObject player)
    {
        if (!dialogueStart)
        {
            if (isPlayerInRange)
            {
                StartDialogue();
            } 
        }
        else if(dialogue.text == mensaje[lineIndex]) 
        {
            NextDialogue();
        }
        
    }
    public void StartDialogue()
    {
        dialogueStart = true;
        panelText.SetActive(true);
        boton.SetActive(true);
        panelControles.SetActive(false);
        recursoVisual.SetActive(false);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    public void NextDialogue()
    {
        lineIndex ++;
        if (lineIndex < mensaje.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogueStart=false;
            panelText.SetActive(false);
            boton.SetActive(false);
            panelControles.SetActive(true);
            recursoVisual.SetActive(true);
        }
    }

    private IEnumerator ShowLine()
    {
        dialogue.text = string.Empty;

        foreach(char ch in mensaje[lineIndex])
        {
            dialogue.text += ch;
            yield return new WaitForSeconds(timeCharacters);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            recursoVisual.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            recursoVisual.SetActive(false);

        }
    }

    
}
