using System.Collections.Generic;
using UnityEngine;

public class ZonaDeCajas : MonoBehaviour

{
    [SerializeField] private int cantidadNecesaria = 3;

    private HashSet<GameObject> objetosEnZona = new HashSet<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (EsObjetoValido(other.gameObject))
        {
            objetosEnZona.Add(other.gameObject);

            Debug.Log("Entr�: " + other.name);

            if (objetosEnZona.Count >= cantidadNecesaria)
            {
                Debug.Log("�Cantidad requerida alcanzada!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (objetosEnZona.Contains(other.gameObject))
        {
            objetosEnZona.Remove(other.gameObject);
            Debug.Log("Sali�: " + other.name);
        }
    }

    private bool EsObjetoValido(GameObject obj)
    {
        // Aqu� validas si es uno de los que deben contarse
        // Por ejemplo, usando tag, componente o nombre
        return obj.CompareTag("ObjetoValido");
    }
}


