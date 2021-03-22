using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammove : MonoBehaviour
{
    private float turnSpeed = 4.0f;
    private Transform posHero;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        posHero = GameObject.Find("hero").transform;
        offset = new Vector3(posHero.position.x, posHero.position.y + 1f, posHero.position.z + 5f);
    }

    // Update is called once per frame
    void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = posHero.position + offset;
        transform.LookAt(posHero.position);
    }
}
