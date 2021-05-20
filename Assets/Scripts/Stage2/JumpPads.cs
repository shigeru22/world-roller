using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPads : MonoBehaviour
{
    Rigidbody rigidbody;
    public float jumpForce = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name=="Sphere"){
            Debug.Log(Physics.gravity);
            rigidbody = other.GetComponent<Rigidbody>();
            //Physics.gravity = new Vector3(0, -1.0F, 0);
            //rigidbody.velocity += (Vector3.up*jumpForce);
            rigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
    /*private void OnTriggerExit(Collider other) {
        Physics.gravity = new Vector3(0, -40.0F, 0);
    }*/
}
