using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI stopwatchText;
    private float elapsedTime;
    private bool isRunning = true;

    private void Update()
    {
        //Solo si está corriendo
        if (isRunning)
        {
            //Incrementar el tiempo transcurrido y mostrar por pantalla
            elapsedTime += Time.deltaTime;
            UpdateStopwatchText();
        }
    }

    private void UpdateStopwatchText()
    {
        //Convertir los valores de decimal a enteros
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        
        //Mostrar el texto
        stopwatchText.text = $"{minutes:00}:{seconds:00}";
    }

    public void ToggleState()
    {
        //Activa o detiene el stopwatch
        isRunning = !isRunning;
    }
    
    public string ExportTime()
    {
        //Convertir los valores de decimal a enteros
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        //Exportar valor en formato string
        return $"{minutes:00}:{seconds:00}";
    }
}