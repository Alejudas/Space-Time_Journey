using UnityEngine;

public class Teleport : MonoBehaviour, IInteractable
{
    [SerializeField] Transform nextP;

    public void Interact(GameObject player)
    {
        player.transform.position = nextP.position;
    }
}
