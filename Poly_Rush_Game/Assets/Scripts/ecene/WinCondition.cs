using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public float delayBeforeSwitch = 3f; // Tiempo en segundos antes de cambiar de escena

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador ha llegado al punto de victoria.");
            // Inicia el proceso de cambiar de escena
            StartCoroutine(WinAndSwitchScene());
        }
    }

    private IEnumerator WinAndSwitchScene()
    {
        Debug.Log("¡El proceso de victoria ha comenzado! Esperando " + delayBeforeSwitch + " segundos...");

        // Espera el tiempo especificado antes de cambiar de escena
        yield return new WaitForSeconds(delayBeforeSwitch);

        // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Índice de la escena actual: " + currentSceneIndex);

        // Calcular el índice de la siguiente escena
        int nextSceneIndex = currentSceneIndex + 1;
        Debug.Log("Índice de la siguiente escena: " + nextSceneIndex);

        // Verificar si hay una escena siguiente disponible
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Cambiando a la siguiente escena...");
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No hay más escenas en la lista.");
            // Aquí podrías reiniciar el juego o mostrar una pantalla final
        }
    }
}