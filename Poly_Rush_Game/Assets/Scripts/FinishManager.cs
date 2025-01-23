using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishManager : MonoBehaviour
{
    [SerializeField] private GameObject finishMenu;
    [SerializeField] private GameObject winGO;
    [SerializeField] private GameObject loseGO;
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private Stopwatch stopwatch;
    private bool isPaused;
 
    public void FinishGame()
    {
        //Finalizar el juego (independientemente de si ganas o pierdes)
        finishMenu.SetActive(true); //Activar UI
        isPaused = true;            //Pausar juego
        scoreTMP.text = stopwatch.ExportTime();     //Mostrar el tiempo de partida
        stopwatch.ToggleState();                    //Detener el reloj
        stopwatch.stopwatchText.text = "";          //Borrar el texto del stopwatch para que solo se vean el finishmenu
    }
    
    public void Win()
    {
        Debug.Log("Win");
        
        //Activar UI de ganar
        winGO.SetActive(true);
        loseGO.SetActive(false);
    }

    public void Defeated()
    {
        //Activar UI de perder
        winGO.SetActive(false);
        loseGO.SetActive(true);
    }
    
    public void BackToMenu()
    {
        //Reanuda el flujo del tiempo y regresa al menu
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
