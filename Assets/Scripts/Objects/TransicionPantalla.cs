using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransicionPantalla : MonoBehaviour
{
    public Image panelNegro;
    public float duracion = 1f;

    public GameObject panelControles; // ← Panel de los botones o joystick
    public PlayerMovement playerMovement;

    public IEnumerator Transicion(System.Action alCompletar)
    {
        // Desactivar los controles antes del viaje y movimiento
        if (panelControles != null)
            panelControles.SetActive(false);
        if (playerMovement != null)
            playerMovement.enabled =false;

        yield return StartCoroutine(Fade(0, 1));

        alCompletar?.Invoke(); // Ejemplo: mover jugador, cambiar escena, etc.

        yield return StartCoroutine(Fade(1, 0));

        // Activar los controles después del viaje y movimiento
        if (panelControles != null)
            panelControles.SetActive(false);
        if (playerMovement != null)
            playerMovement.enabled = true;

    }

    private IEnumerator Fade(float inicio, float fin)
    {
        float tiempo = 0f;
        Color color = panelNegro.color;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float alpha = Mathf.Lerp(inicio, fin, tiempo / duracion);
            panelNegro.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        panelNegro.color = new Color(color.r, color.g, color.b, fin);
    }
}
