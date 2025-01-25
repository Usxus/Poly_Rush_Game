using UnityEngine;

public class ActivacionConfetti : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ParticleSystem[] particleSystems;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (ParticleSystem particle in particleSystems)
            {
                particle.Play();
            }

  
        }
    }


}
