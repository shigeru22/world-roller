using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways] // apply changes directly both in edit and play mode
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 constraint;
    bool warned = false;
    bool isCamera = true;

    void Awake()
    {
        Camera temp = GetComponent<Camera>();
        if(!temp)
        {
            Debug.LogError("Object is not camera or doesn't contain Camera component.");
            isCamera = false;
        }
    }

    void Update()
    {
        if(isCamera)
        {
            if (target)
            {
                if (warned) warned = false;

                Vector3 temp = target.position;
                temp.x += constraint.x;
                temp.y += constraint.y;
                temp.z += constraint.z;
                transform.position = temp;
            }
            else if (!warned)
            {
                Debug.LogError("Target is not specified.");
                warned = true;
            }
        }

        // TODO: add rotation if Q or E is pressed (and lerp it)
    }
}
