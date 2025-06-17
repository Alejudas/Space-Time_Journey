using UnityEngine;
using System.Collections;

public class Grifos : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource sonido;
    [SerializeField] private GameObject siguienteOb;
    [SerializeField] private ArrowGuide flecha;
    [SerializeField] private Transform nuevoDestino;
    public PlayerMovement pm;
    public void Interact(GameObject player)
    {
        StartCoroutine(TaskComplete());
    }

    private IEnumerator TaskComplete()
    {
        if (pm != null)
            pm.enabled = false;

        // Sonido del grifo
        if (sonido != null)
            sonido.Play();

        // Espera un poco para simular tiempo de ejecución
        yield return new WaitForSeconds(2f);

        // Activar siguiente puzzle
        if (siguienteOb != null)
            siguienteOb.SetActive(true);

        // Cambiar destino de la flecha
        if (flecha != null && nuevoDestino != null)
            flecha.ChangeTarget(nuevoDestino);

        if (pm != null)
            pm.enabled = true;
    }
}