using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransicionPantalla : MonoBehaviour
{
    public Image panelNegro;
    public float duracion = 1f;

    public GameObject portalAnimObj; // El objeto que contiene el Animator
    public GameObject panelControles;
    public GameObject panelFlecha;
    public PlayerMovement pm;
    public IEnumerator Transicion(System.Action alCompletar)
    {

        if (panelControles != null)
            panelControles.SetActive(false);
        if (panelControles != null)
            panelControles.SetActive(false);
        if (pm != null)
            pm.enabled = false;
        yield return StartCoroutine(Fade(0, 1));

        // Mostrar animación del portal
        if (portalAnimObj != null)
        {
            portalAnimObj.SetActive(true);
            yield return new WaitForSeconds(1.5f); // o la duración del loop de animación
        }

        alCompletar?.Invoke();

        // Espera un momento para dejar visible el portal después del cambio
        yield return new WaitForSeconds(0.5f);
        if (portalAnimObj != null)
            portalAnimObj.SetActive(false);

        yield return StartCoroutine(Fade(1, 0));

        if (panelControles != null)
            panelControles.SetActive(true);
        if (pm != null)
            pm.enabled = true;
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