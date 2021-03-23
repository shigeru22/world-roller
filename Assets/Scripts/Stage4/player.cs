using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int gate = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate world instead, use InputManager.Instance.horizontal and vertical later
        /*
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        this.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 10f);
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gate")
        {
            gate++;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Debug.Log(gate);
        }
    }
}
