using UnityEngine;

public class ActivacionConfetti : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ParticleSystem particleSystem;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
        
            particleSystem.Play();

  
        }
    }


}
