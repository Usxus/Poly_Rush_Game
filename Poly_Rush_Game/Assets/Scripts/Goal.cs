using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private FinishManager finishManager;

    private void OnTriggerEnter(Collider other)
    {
        //Si el jugador toca la meta...
        if (other.CompareTag("Player"))
        {
            //Finalizar el juego y mandar UI de victoria
            finishManager.FinishGame();
            finishManager.Win();
        }
    }
}
