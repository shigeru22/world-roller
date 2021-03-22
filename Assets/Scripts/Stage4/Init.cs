using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    Rigidbody rigid;
    Vector3 force;
    // Start is called before the first frame update
    void Start()
    {
        force = 1000f * transform.forward;
        rigid = this.GetComponent<Rigidbody>();
        rigid.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        if(rigid.velocity.sqrMagnitude < 0.1f)
        {
            rigid.AddForce(force);
        }
    }
}
