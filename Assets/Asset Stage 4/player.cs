using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    int gate = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        this.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 10f);
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
