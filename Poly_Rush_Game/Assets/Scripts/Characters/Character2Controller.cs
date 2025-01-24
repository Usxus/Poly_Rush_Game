using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2Controller : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f; // Velocidad de movimiento
    public float velocidadRotacion = 200.0f; // Velocidad de rotación
    public float fuerzaSalto = 5.0f;         // Fuerza del salto
    private Animator anim;                   // Componente Animator
    private Rigidbody rb;                    // Componente Rigidbody
    public float x, y;                       // Valores de entrada
    private bool enSuelo = true;             // Verifica si el personaje está en el suelo
    private bool saltoEnCurso = false;       // Verifica si el salto ya está en curso
    private bool canMove = true;             // Controla si el jugador puede moverse

    [SerializeField] private RagDoll ragDoll; // Componente Ragdoll
    [SerializeField] private FinishManager finishManager;

    // Propiedad pública para verificar si el personaje está en el suelo
    public bool Grounded
    {
        get { return enSuelo; }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
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
        ragDoll.SetEnabled(false); // Deshabilitar el Ragdoll
        anim.enabled = true;      // Habilitar animaciones
    }

    private void Saltar()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        enSuelo = false; // El personaje ya no está en el suelo
        saltoEnCurso = true; // Marca que el salto está en curso
        anim.SetTrigger("Saltar"); // Activa la animación de salto
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
            saltoEnCurso = false; // Permite hacer un salto nuevamente
        }

        // Si colisiona con un enemigo, activa el Ragdoll
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DisablePlayer();
            Debug.Log("Jugador muerto. Ragdoll activado.");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            enSuelo = true;
        }
    }

    private void Movement()
    {
        // Capturar la entrada del usuario
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Rotación del personaje
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);

        // Movimiento hacia adelante y atrás
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
