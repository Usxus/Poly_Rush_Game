using UnityEngine;

public class PenduloMovement : MonoBehaviour
{
    public float amplitud = 2f; // Ajusta la amplitud según necesites
    public float periodo = 2f; // Ajusta el periodo según necesites

    private float angle = 0f;

    void Update()
    {
        // Calcular el ángulo en función del tiempo y el periodo
        angle += 2 * Mathf.PI * Time.deltaTime / periodo;

        // Aplicar la rotación al objeto
        transform.rotation = Quaternion.Euler(Mathf.Sin(angle) * amplitud, 0, 0);
    }


}
