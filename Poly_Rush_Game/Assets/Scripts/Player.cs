using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 200f; 
    public Transform cameraTransform; 
    private float verticalRotation;
    private bool canMove = true;

    [SerializeField] private RagDoll ragDoll;
    [SerializeField] private FinishManager finishManager;

    private void Update()
    {
        if (canMove)
        {
            //Solo puede moverse y rotar mientras la partida esta en curso
            Movement();
            RotateCamera();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //Probar RagDoll
            DisablePlayer();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            //Salir de Ragdoll y jugar
            EnablePlayer();
        }
    }

    public void DisablePlayer()
    {
        canMove = false;
        ragDoll.SetEnabled(true);
    }

    public void EnablePlayer()
    {
        canMove = true;
        ragDoll.SetEnabled(false);
    }

    private void Movement()
    {
        //Asignar los inputs vettical y horizontal predeterminados de Unity
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        //Avanzar hacia donde mira la camara
        //"Adelante" es relativo depende hacia donde mires
        Vector3 movement = (cameraTransform.forward * verticalInput + cameraTransform.right * horizontalInput).normalized;
        transform.position += movement * (speed * Time.deltaTime);
        
        //Asegurar que el jugador se mantenga en Y=0 (nivel de piso)
        Vector3 fixedPosition = new Vector3(transform.position.x, 0, transform.position.z);
        transform.position = fixedPosition;
    }

    private void RotateCamera()
    {
        //Tomar el valor de MouseX para rotar al jugador
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        //Toma el valor de MouseY y la limita a una altura minima y maxima
        //(Evita que puedas girar como en una bola para hamsters)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        //Establece la rotacion de la camara
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
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
