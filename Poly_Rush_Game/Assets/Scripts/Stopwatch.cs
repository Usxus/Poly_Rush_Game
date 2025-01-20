using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI stopwatchText;
    private float elapsedTime = 0f;
    private bool isRunning = true;

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateStopwatchText();
        }
    }

    private void UpdateStopwatchText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        stopwatchText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ToggleState()
    {
        isRunning = !isRunning;
    }

    public void ResetStopwatch()
    {
        elapsedTime = 0f;
        UpdateStopwatchText();
    }
    
    public string ExportTime()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}