using System.Collections;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    public ParticleSystem sistemaParticulas;

    void Start()
    {
        // Detener la emisi�n despu�s de 1 segundo
        Invoke("DetenerParticulas", 0.5f);
    }

    void DetenerParticulas()
    {
        sistemaParticulas.Stop();
    }
}