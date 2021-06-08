using UnityEngine;

public class JumpPads : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            rb = other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}