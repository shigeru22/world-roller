using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    [SerializeField] float tiltSpeed;

    void Update()
    {
        float horizontal = -InputManager.Instance.horizontal * 20f;
        float vertical = InputManager.Instance.vertical * 20f;
        var target = Quaternion.Euler(vertical, 0, horizontal);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * tiltSpeed);
    }
}
