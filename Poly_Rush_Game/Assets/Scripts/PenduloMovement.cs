using UnityEngine;

public class PenduloMovement : MonoBehaviour
{
    public float amplitud = 2f; // Ajusta la amplitud seg�n necesites
    public float periodo = 2f; // Ajusta el periodo seg�n necesites

    private float angle = 0f;

    void Update()
    {
        // Calcular el �ngulo en funci�n del tiempo y el periodo
        angle += 2 * Mathf.PI * Time.deltaTime / periodo;

        // Aplicar la rotaci�n al objeto
        transform.rotation = Quaternion.Euler(Mathf.Sin(angle) * amplitud, 0, 0);
    }


}
