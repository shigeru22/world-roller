using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public float speed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Debug.Log($"Health: {GameManager.Instance.health}, Lives: {GameManager.Instance.lives}");
    }

    void Update()
    {
        rb.AddForce(Vector3.forward * InputManager.Instance.vertical * speed * 100f * Time.deltaTime);
        rb.AddForce(Vector3.right * InputManager.Instance.horizontal * speed * 100f * Time.deltaTime);
    }
}
