using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 constraint;
    bool warned = false;
    bool isCamera = true;

    void Awake()
    {
        Camera temp = GetComponent<Camera>();
        if (!temp)
        {
            Debug.LogError("Object is not camera or doesn't contain Camera component.");
            isCamera = false;
        }
    }

    void Update()
    {
        if (isCamera)
        {
            if (target)
            {
                if (warned) warned = false;

                // TODO: rotate camera if left or right rotate pressed
            }
            else if (!warned)
            {
                Debug.LogError("Target is not specified.");
                warned = true;
            }
        }
    }
}
