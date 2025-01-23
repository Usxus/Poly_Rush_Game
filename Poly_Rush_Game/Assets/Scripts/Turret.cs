using System.Collections;
using UnityEngine;
public class Turret : MonoBehaviour
{
    //Variables privadas pero asignables desde el inspector
    [SerializeField] private GameObject fire;
    [SerializeField] private float toggleInterval = 1.0f;

    private void Start()
    {
        StartCoroutine(ToggleCoroutine());
    }

    private IEnumerator ToggleCoroutine()
    {
        while (true) //Permanentemente activado
        {
            //Encender y apagar el fuego después del periodo asignado
            fire.SetActive(!fire.activeSelf);
            yield return new WaitForSeconds(toggleInterval);
        }
    }
}