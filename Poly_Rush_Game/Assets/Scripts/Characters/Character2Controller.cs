using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2Controller : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f; // Velocidad de movimiento
    public float velocidadRotacion = 200.0f; // Velocidad de rotaci�n
    public float fuerzaSalto = 5.0f;         // Fuerza del salto
    private Animator anim;                   // Componente Animator
    private Rigidbody rb;                    // Componente Rigidbody
    public float x, y;                       // Valores de entrada
    private bool enSuelo = true;             // Verifica si el personaje est� en el suelo
    private bool saltoEnCurso = false;       // Verifica si el salto ya est� en curso

    // Propiedad p�blica para verificar si el personaje est� en el suelo
    public bool Grounded
    {
        get { return enSuelo; }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Rotaci�n del personaje
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);

        // Movimiento hacia adelante y atr�s
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        // Actualizar animaciones
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        // Salto solo si estamos en el suelo y no hay otro salto en curso
        if (Input.GetButtonDown("Jump") && enSuelo && !saltoEnCurso)
        {
            Saltar();
            saltoEnCurso = true; // Marca que el salto est� en curso
        }

        // Detener la animaci�n de salto cuando el personaje toca el suelo
        if (enSuelo && saltoEnCurso)
        {
            anim.SetTrigger("Saltar"); // Detiene la animaci�n de salto cuando el personaje est� en el suelo
        }
    }

    private void Saltar()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        enSuelo = false; // El personaje ya no est� en el suelo
        anim.SetTrigger("Saltar"); // Activa la animaci�n de salto
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si el personaje toca el suelo, reseteamos el salto
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
            saltoEnCurso = false; // Permite hacer un salto nuevamente
            anim.SetTrigger("Saltar"); // Detiene la animaci�n de salto
            Debug.Log("En el suelo");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Verifica que seguimos tocando el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
        }
    }
}
