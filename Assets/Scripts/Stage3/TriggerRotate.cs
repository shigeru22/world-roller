using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRotate : MonoBehaviour
{
    [SerializeField]
    Transform world;
    int rotation = 0;
    float delay = 0;
    [SerializeField]
    int numberOfGates;
    int gates = 0;
    [SerializeField]
    BoxCollider trigger;
    [SerializeField]
    float force = 5000f;
    // Start is called before the first frame update
    void Start()
    {
        trigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        world.localRotation = Quaternion.Slerp(world.localRotation, Quaternion.Euler(new Vector3(0, 0, -90) * rotation), 0.01f);
        int layerMask = 1 << 6;

        layerMask = ~layerMask;

        //Debug.DrawRay(transform.position, -Vector3.up * 100f, Color.red);
        if (Physics.Raycast(transform.position + new Vector3(0, 10f, 0), -Vector3.up, 1000f, layerMask))
        {
            delay = 0;
            //Debug.Log("Did Hit");
        }
        else
        {
            delay += Time.deltaTime;
            if (delay > 2f)
            {
                rotation = 0;
            }
            // Debug.LogError("Did not Hit");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("JumpPads3"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RotateWorld"))
        {
            rotation = 1;
        }
        else if(other.gameObject.CompareTag("Gate"))
        {
            gates++;
            if(gates == numberOfGates)
            {
                trigger.enabled = true;
            }
        }
    }
}
