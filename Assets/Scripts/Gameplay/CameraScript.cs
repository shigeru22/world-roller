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

    bool isWall = false;
    float t = 0.0f;
    float delay = 0.0f;
    Vector3 tempPosCam;
    Vector3 tempPosBall;

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
                if (InputManager.Instance.left) GameManager.Instance.RotateWorld(RotationTargets.Left);
                else if (InputManager.Instance.right) GameManager.Instance.RotateWorld(RotationTargets.Right);
                currentRotation = Quaternion.Slerp(currentRotation, Quaternion.Euler(Vector3.up * GameManager.Instance.worldRotation), 0.05f);
                pivot.transform.rotation = currentRotation;
                Vector3 temp = currentRotation.eulerAngles;
                temp.x += rotation.x;
                temp.y += rotation.y;
                temp.z += rotation.z;
                if (InputManager.Instance.damp)
                {
                    if (InputManager.Instance.vertical > 0f)
                    {
                        temp.x += 45f;
                    }
                    else if (InputManager.Instance.vertical < 0f)
                    {
                        temp.x -= 45f;
                    }
                }
                currentRotation = Quaternion.Slerp(currentRotation, Quaternion.Euler(temp), 0.05f);
                pivot.transform.rotation = currentRotation;
            }
            else if (!warned)
            {
                Debug.LogError("Target is not specified.");
                warned = true;
            }

            raycast();
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
        transform.localRotation = Quaternion.Euler(Vector3.zero);
    }

    void raycast()
    {
        float raylength = 3.5f;

        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Debug.DrawRay(ray.origin, ray.direction * raylength, Color.red);
        //Debug.DrawRay(this.transform.position, target.position, Color.red);

        //It just works.
        if (Physics.Raycast(ray, out hit, raylength) && isWall == false)
        //if (Physics.Raycast(this.transform.position, target.position, 3f))
        {
            delay += Time.deltaTime;
            if (delay > 0.2f)
            {
                isWall = true;
                t = 0.0f;
                tempPosCam = this.transform.localPosition;
                tempPosBall = (tempPosCam + target.position) / 2;
            }

            //this.transform.LookAt(target);
            //this.transform.Translate(Vector3.forward * 4, Space.Self);
        }
        else
        {
            delay = 0;
        }

        if (isWall)
        {
            this.transform.LookAt(target);
            t += Time.deltaTime;
            //this.transform.position = Vector3.Lerp(tempPosCam, tempPosBall, t * 2);
            // transform.Translate(Vector3.Lerp(tempPosCam, tempPosCam+(Vector3.forward*8)+(-Vector3.up*1), t * 2), Space.Self);
            transform.Translate(Vector3.Lerp(tempPosCam, tempPosCam + (Vector3.forward * 8) + (-Vector3.up * 1), t * 2), Space.Self);
            // Vector3 temp = new Vector3(tempPosCam.x, tempPosCam.y, tempPosCam.z);
            // temp += (Vector3.forward * 6) + (-Vector3.up * 1);
            // transform.localPosition = temp;
            if (!Physics.Raycast(ray, out hit, raylength))
            {
                isWall = false;
            }
        }
    }
}
