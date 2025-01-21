using UnityEngine;

public class RagDoll : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Rigidbody[] rigibodies;
    
    void Start()
    {
        rigibodies = transform.GetComponentsInChildren<Rigidbody>();
    }

    public void SetEnabled(bool isEnabled)
    {
        bool isKinematic = !isEnabled;
        foreach (Rigidbody rb in rigibodies)
        {
            rb.isKinematic = isKinematic;
        }
        animator.enabled = !isEnabled;
    }
}