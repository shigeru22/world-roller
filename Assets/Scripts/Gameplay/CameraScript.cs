using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteAlways] // apply changes directly both in edit and play mode
public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 constraint;
    [SerializeField] Vector3 rotation;
    [SerializeField] bool followLocalPosition;

    bool warned = false;
    bool isCamera = true;

    GameObject main;
    GameObject pivot;
    Vector3 currentPosition;
    Quaternion currentRotation;

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
            // GameManager.Instance.ResetWorldRotation();
            if (transform.localRotation != Quaternion.Euler(Vector3.zero)) throw new InvalidValueException("Rotation value must be Vector3.zero (0, 0, 0)");

            Transform parent;
            parent = transform.parent;

            main = new GameObject("Camera");
            pivot = new GameObject("PivotPoint");

            main.transform.position = target.position;
            pivot.transform.position = target.position;

            pivot.transform.SetParent(main.transform);
            transform.SetParent(pivot.transform);
            main.transform.SetParent(parent);
            currentPosition = constraint;
            currentRotation = transform.rotation;
            // cameraRotation = transform.localEulerAngles;
            MoveCamera();
        }
    }

    void LateUpdate()
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
                // TODO: Change keycodes from user data
                if (Input.GetKeyDown(KeyCode.Q)) GameManager.Instance.RotateWorld(RotationTargets.Left);
                else if (Input.GetKeyDown(KeyCode.E)) GameManager.Instance.RotateWorld(RotationTargets.Right);
                currentRotation = Quaternion.Slerp(currentRotation, Quaternion.Euler(Vector3.up * GameManager.Instance.worldRotation), 0.05f);
                pivot.transform.rotation = currentRotation;

                // rotate
                Vector3 temp = currentRotation.eulerAngles;
                temp.x += rotation.x;
                temp.y += rotation.y;
                temp.z += rotation.z;
                pivot.transform.rotation = Quaternion.Euler(temp);
            }
            else if (!warned)
            {
                Debug.LogError("Target is not specified.");
                warned = true;
            }
        }
    }

    void MoveCamera()
    {
        Vector3 temp;

        if (followLocalPosition) temp = target.localPosition;
        else temp = target.position;
        main.transform.localPosition = temp;

        temp = pivot.transform.localPosition;
        temp.x += currentPosition.x;
        temp.y += currentPosition.y;
        temp.z += currentPosition.z;
        // Debug.Log(temp);
        transform.localPosition = temp;
    }
}
