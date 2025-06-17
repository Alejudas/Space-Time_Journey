using UnityEngine;
using UnityEngine.SceneManagement;

public class AstroGirl : MonoBehaviour, IInteractable
{
    public void Interact(GameObject player)
    {
        SceneManager.LoadScene("Credits");
    }

    
}
