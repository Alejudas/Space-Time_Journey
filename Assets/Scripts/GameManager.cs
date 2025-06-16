using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    public delegate void GameManagerDelegate();
    public GameManagerDelegate GameStart;
    public GameManagerDelegate PauseGame;
    public GameManagerDelegate ResumeGame;
    public GameManagerDelegate GameOver;
    public GameManagerDelegate RestartGame;

    // Objetos
    public GameObject pausePanel;
    public GameObject controllsPanel;
    public GameObject portalAnimObject; 

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
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        GameStart?.Invoke();
        StartCoroutine(TransitionAndStart());
    }

    private System.Collections.IEnumerator TransitionAndStart()
    {
        if (portalAnimObject != null)
        {
            portalAnimObject.SetActive(true); 
        }

        yield return new WaitForSeconds(1.5f); 

        SceneManager.LoadScene("Escena de pruebas");
        Time.timeScale = 1;
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        controllsPanel.SetActive(false);
        PauseGame?.Invoke();
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        controllsPanel.SetActive(true);
        ResumeGame?.Invoke();
        Time.timeScale = 1;
    }

    public void End()
    {
        GameOver?.Invoke();
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1;
    }

    public void Close()
    {
        Application.Quit();
    }

    public void Restart()
    {
        RestartGame?.Invoke();
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
