using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransicionPantalla : MonoBehaviour
{
    public Image panelNegro;
    public float duracion = 1f;

    public IEnumerator Transicion(System.Action alCompletar)
    {
        yield return StartCoroutine(Fade(0, 1));
        alCompletar?.Invoke();
        yield return StartCoroutine(Fade(1, 0));
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
