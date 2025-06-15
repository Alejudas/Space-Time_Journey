using UnityEngine;

public class ArrowGuide : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private RectTransform flechaUI; // La imagen de la flecha
    [SerializeField] private float bordeOffset = 50f; // Separación del borde de pantalla

    void Update()
    {
        if (objetivo == null) return;

        Vector3 posEnPantalla = Camera.main.WorldToScreenPoint(objetivo.position);

        // Verificar si el objetivo está fuera de la pantalla
        bool fueraPantalla = posEnPantalla.z < 0 ||
                             posEnPantalla.x < 0 || posEnPantalla.x > Screen.width ||
                             posEnPantalla.y < 0 || posEnPantalla.y > Screen.height;

        if (fueraPantalla)
        {
            // Calcular dirección desde el centro de la pantalla al objetivo
            Vector3 direccion = (posEnPantalla - new Vector3(Screen.width, Screen.height, 0) / 2).normalized;

            // Posicionar la flecha en el borde
            Vector3 nuevaPos = new Vector3(Screen.width, Screen.height, 0) / 2 + direccion * ((Screen.height / 2) - bordeOffset);
            flechaUI.position = nuevaPos;

            // Rotarla hacia el objetivo
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            flechaUI.rotation = Quaternion.Euler(0, 0, angulo);
        }
        else
        {
            flechaUI.gameObject.SetActive(false); // Ocultar si está en pantalla
        }
    }
    public void ChangeTarget(Transform nuevoObjetivo)
    {
        objetivo = nuevoObjetivo;
        flechaUI.gameObject.SetActive(true); // Opcional: volver a mostrar si estaba oculta
    }

}