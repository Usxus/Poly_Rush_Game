using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; 
    public Button resumeButton; 
    private bool isPaused;

    void Start()
    {
        //Desactivar el ui de pausa al iniciar el juego
        pauseMenu.SetActive(false); 
        resumeButton.onClick.AddListener(ResumeGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Usar ESC para pausar y reanudar el juego
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    void PauseGame()
    {
        //Pausar detiene el flujo del juego y muestra el UI de pausa
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        //Reanudar continua el flujo del juego y cierra el UI
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    
    public void ChangeScene(int scene)
    {
        //El boton de Exit te manda al menu
        SceneManager.LoadScene(scene);
    }
}
