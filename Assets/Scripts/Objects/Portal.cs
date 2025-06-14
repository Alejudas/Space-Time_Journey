using UnityEngine;

public class Teleport : MonoBehaviour, IInteractable
{
    [SerializeField] Transform nextP;
    [SerializeField] TransicionPantalla transicionPantalla;

    public void Interact(GameObject player)
    {
        if (transicionPantalla != null)
        {
            player.GetComponent<MonoBehaviour>().StartCoroutine(
                transicionPantalla.Transicion(() =>
                {
                    player.transform.position = nextP.position;
                })
            );
        }
        else
        {
            player.transform.position = nextP.position;
        }
    }
}
