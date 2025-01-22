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
        finishMenu.SetActive(true);
        isPaused = true;
        scoreTMP.text = stopwatch.ExportTime();
        stopwatch.ToggleState();
        stopwatch.stopwatchText.text = "";
    }
    
    public void Win()
    {
        Debug.Log("Win");
        //Activar las particulaas aqui
        winGO.SetActive(true);
        loseGO.SetActive(false);
    }

    public void Defeated()
    {
        winGO.SetActive(false);
        loseGO.SetActive(true);
    }
    
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
