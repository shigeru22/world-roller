using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteAlways] // apply changes directly both in edit and play mode
public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 constraint;

    bool warned = false;
    bool isCamera = true;

    GameObject main;
    GameObject pivot;
    Vector3 current;

    void Awake()
    {
        Camera temp = GetComponent<Camera>();
        if(!temp)
        {
            Debug.LogError("Object is not camera or doesn't contain Camera component.");
            isCamera = false;
        }

        if(isCamera)
        {
            GameManager.Instance.ResetWorldRotation();

            main = new GameObject("Camera");
            pivot = new GameObject("PivotPoint");

            main.transform.position = target.position;
            pivot.transform.position = target.position;

            pivot.transform.SetParent(main.transform);
            transform.SetParent(pivot.transform);
            current = constraint;
            MoveCamera();
        }
    }

    void Update()
    {
        if(isCamera)
        {
            if (target)
            {
                if (warned) warned = false;
                MoveCamera();

                /*
                if (InputManager.Instance.left) currentRotation += 90f;
                else if (InputManager.Instance.right) currentRotation -= 90f;
                */

                // test
                if (Input.GetKeyDown(KeyCode.Q)) GameManager.Instance.RotateWorld(RotationTargets.Left);
                else if (Input.GetKeyDown(KeyCode.E)) GameManager.Instance.RotateWorld(RotationTargets.Right);
                pivot.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.up * GameManager.Instance.worldRotation), 0.05f);
            }
            else if (!warned)
            {
                Debug.LogError("Target is not specified.");
                warned = true;
            }
        }

        // TODO: add rotation if Q or E is pressed (and lerp it)
    }

    void MoveCamera()
    {
        Vector3 temp = target.position;
        main.transform.localPosition = temp;

        temp = pivot.transform.localPosition;
        temp.x += current.x;
        temp.y += current.y;
        temp.z += current.z;
        // Debug.Log(temp);
        transform.localPosition = temp;
    }
}
