using UnityEngine;

public class Init : MonoBehaviour
{
    Rigidbody rigid;
    Vector3 force;

    void Start()
    {
        force = 500f * transform.forward;
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(force);
    }

    void Update()
    {
        if (rigid.velocity.sqrMagnitude < 1f)
        {
            rigid.AddForce(force);
        }
    }
}
