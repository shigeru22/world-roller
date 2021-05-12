using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    [SerializeField] float tiltSpeed;

    void Update()
    {
        if (!GameManager.Instance.isPlaying) return;
        
        float horizontal, vertical;
        int rotation = (int)Mathf.Abs(GameManager.Instance.worldRotation / 90f % 4f);

        if(rotation == 1)
        {
            Debug.Log("enter");
            horizontal = InputManager.Instance.vertical * 20f;
            vertical = InputManager.Instance.horizontal * 20f;
        }
        else if(rotation == 2)
        {
            horizontal = InputManager.Instance.horizontal * 20f;
            vertical = -InputManager.Instance.vertical * 20f;
        }
        else if(rotation == 3)
        {
            // 90
            horizontal = -InputManager.Instance.vertical * 20f;
            vertical = -InputManager.Instance.horizontal * 20f;
        }
        else
        {
            horizontal = -InputManager.Instance.horizontal * 20f;
            vertical = InputManager.Instance.vertical * 20f;
        }

        Quaternion target = Quaternion.Euler(vertical, 0, horizontal);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * tiltSpeed);
    }
}
