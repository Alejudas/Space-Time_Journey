using UnityEngine;
using System.Collections;

public class Grifos : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource sonidoGrifo;
    [SerializeField] private GameObject siguienteGrifo;
    [SerializeField] private ArrowGuide flecha;
    [SerializeField] private Transform nuevoDestino;

    public void Interact(GameObject player)
    {
        StartCoroutine(TaskComplete());
    }

    private IEnumerator TaskComplete()
    {
        // Sonido del grifo
        if (sonidoGrifo != null)
            sonidoGrifo.Play();

        // Espera un poco para simular tiempo de ejecución
        yield return new WaitForSeconds(2f);

        // Activar siguiente grifo
        if (siguienteGrifo != null)
            siguienteGrifo.SetActive(true);

        // Cambiar destino de la flecha
        if (flecha != null && nuevoDestino != null)
            flecha.ChangeTarget(nuevoDestino);
    }
}