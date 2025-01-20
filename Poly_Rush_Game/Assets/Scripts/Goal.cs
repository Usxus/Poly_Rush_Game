using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private FinishManager finishManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            finishManager.FinishGame();
            finishManager.Win();
        }
    }
}
