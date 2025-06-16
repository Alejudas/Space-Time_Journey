using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    public delegate void Delegate();
    public Delegate GameStart;
    public Delegate PauseGame;
    public Delegate ResumeGame;
    public Delegate GameOver;

    //Objetos

    public GameObject pausePanel;
    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 0f;
    }

    public void IniciarJuego()
    {
        GameStart?.Invoke();
        SceneManager.LoadScene("Escena de pruebas");
        Time.timeScale = 1;
    }
    public void PausarJuego()
    {
    //    if (pausePanel != null && !pausePanel.activeSelf)
    //    {
            pausePanel.SetActive(true);
        //}
        PauseGame?.Invoke();
        Time.timeScale = 0;
    }
    public void ReanudarJuego()
    {
        pausePanel.SetActive(false);
        ResumeGame?.Invoke();
        Time.timeScale = 1;
    }
    public void FinalizarJuego()
    {
        GameOver?.Invoke();

        Time.timeScale = 1;
    }
    public void CerrarJuego()
    {
        Application.Quit();
    }

}
