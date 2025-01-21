using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject targetObject;
    public float toggleInterval = 1.0f;

    private void Start()
    {
        StartCoroutine(ToggleCoroutine());
    }

    private IEnumerator ToggleCoroutine()
    {
        if (targetObject == null)
        {
            Debug.LogError("No hay targetobject");
            yield break;
        }

        while (true)
        {
            targetObject.SetActive(!targetObject.activeSelf);
            yield return new WaitForSeconds(toggleInterval);
        }
    }
}