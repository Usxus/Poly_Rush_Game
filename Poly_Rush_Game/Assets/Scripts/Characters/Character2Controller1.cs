using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2Controller1 : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f; // Velocidad de movimiento
    public float velocidadRotacion = 200.0f; // Velocidad de rotaci�n
    public float fuerzaSalto = 5.0f;         // Fuerza del salto
    private Animator anim;                   // Componente Animator
    private Rigidbody rb;                    // Componente Rigidbody
    public float x, y;                       // Valores de entrada
    private bool enSuelo = true;             // Verifica si el personaje est� en el suelo
    private bool saltoEnCurso = false;       // Verifica si el salto ya est� en curso
    private bool canMove = true;             // Controla si el jugador puede moverse

    [SerializeField] private RagDoll ragDoll; // Componente Ragdoll
    [SerializeField] private FinishManager finishManager;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DisablePlayer();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            EnablePlayer();
        }
        
        if (canMove)
        {
            Movement();
        }

        // Salto solo si estamos en el suelo y no hay otro salto en curso
        if (Input.GetButtonDown("Jump") && enSuelo && !saltoEnCurso)
        {
            Saltar();
        }
    }

    public void DisablePlayer()
    {
        canMove = false;
        ragDoll.SetEnabled(true); // Habilitar el Ragdoll
        anim.enabled = false;    // Desactivar animaciones
    }

    public void EnablePlayer()
    {
        canMove = true;
        ragDoll.SetEnabled(false); // Habilitar el Ragdoll
        anim.enabled = true; 
    }


    private void Saltar()
    {
        Debug.Log("SSalto");
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        enSuelo = false; // El personaje ya no est� en el suelo
        saltoEnCurso = true; // Marca que el salto est� en curso
        anim.SetBool("EnSuelo", false);
        anim.SetTrigger("Saltar"); // Activa la animaci�n de salto
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && saltoEnCurso)
        {
            Debug.Log("Aterrizaje");
            saltoEnCurso = false; // Permite hacer un salto nuevamente
            anim.SetBool("EnSuelo", true);
        }

        // Verificar si el objeto tiene el tag "Fire"
        if (collision.gameObject.CompareTag("Fire") && !canMove)
        {
            
            // Habilitar el ragdoll
            ragDoll.SetEnabled(true);
            anim.enabled = false; // Desactivar animaciones
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Tocando suelo");
            enSuelo = true;
        }
    }

    private void Movement()
    {
        // Capturar la entrada del usuario
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Rotaci�n del personaje
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);

        // Movimiento hacia adelante y atr�s
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);

        // Actualizar animaciones
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire") && canMove)
        {
            //Si tocas el fuego te mueres
            DisablePlayer();
            finishManager.FinishGame();
            finishManager.Defeated();
        }
    }
}
