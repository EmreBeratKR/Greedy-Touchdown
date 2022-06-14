using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RugbyBall : MonoBehaviour
{
    [SerializeField] private float throwForce; 
        
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void OnPlayerThrowBall()
    {
        Throw();
    }

    public void OnPlayerRagdollActivated()
    {
        transform.parent = null;
        body.isKinematic = false;
        body.useGravity = true;
    }

    private void Throw()
    {
        transform.parent = null;
        body.isKinematic = false;
        body.useGravity = true;
        body.AddForce(transform.up * -throwForce, ForceMode.VelocityChange);
    }
}
