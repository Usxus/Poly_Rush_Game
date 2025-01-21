using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 200f; 
    public Transform cameraTransform; 
    private float verticalRotation = 0f;
    private bool canMove = true;

    [SerializeField] private RagDoll ragDoll;

    private void Update()
    {
        if (canMove)
        {
            Movement();
            RotateCamera();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            DisablePlayer();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = (cameraTransform.forward * verticalInput + cameraTransform.right * horizontalInput).normalized;
        transform.position += movement * (speed * Time.deltaTime);
        Vector3 fixedPosition = new Vector3(transform.position.x, 0, transform.position.z);
        transform.position = fixedPosition;
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.CompareTag("Car"))
        {
            canMove = false;
            ragDoll.SetEnabled(true);
        }
        */
    }
}
