using UnityEngine;

public class ArrowGuide : MonoBehaviour
{
    [SerializeField] private Transform jugador;
    private Transform destinoActual;

    void Update()
    {
        if (destinoActual == null) return;

        Vector3 direccion = destinoActual.position - jugador.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    public void ChangeTarget(Transform nuevoDestino)
    {
        destinoActual = nuevoDestino;
    }
}