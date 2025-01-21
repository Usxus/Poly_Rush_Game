using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private bool canMove = true;
    [SerializeField] private RagDoll ragDoll;

    private void Update()
    {
        if(canMove) Movement();
        if (Input.GetKeyDown(KeyCode.R))
        {
            canMove = false;
            ragDoll.SetEnabled(true);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            canMove = true;
            ragDoll.SetEnabled(false);
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * (speed * Time.deltaTime);
        transform.position += movement;
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


