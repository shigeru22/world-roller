using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour
{
    [SerializeField] Transform worldObject;
    [SerializeField] Transform ballObject;
    [SerializeField] float tiltSpeed;

    void Start()
    {
        GameObject temp = new GameObject();
        temp.gameObject.name = "Tilter";

        if (worldObject == null)
        {
            // assume this object
            worldObject = GetComponent<Transform>();
        }

        if(ballObject == null)
        {
            // find "ball" or "sphere" later
        }

        gameObject.transform.parent = temp.transform;
        

        Vector3 angle = temp.transform.localEulerAngles;
        angle.x -= 10f;
        angle.z -= 10f;
        temp.transform.localEulerAngles = angle;
        ballObject.transform.parent = temp.transform;

        // Debug.Log($"Target object rotation: {worldObject.localEulerAngles.x}, {worldObject.localEulerAngles.y}, {worldObject.localEulerAngles.z}");
    }

    void Update()
    {
        Vector3 temp = worldObject.localEulerAngles;

        temp.x = Mathf.Lerp(temp.x, InputManager.Instance.vertical * 10, 0.5f);
        temp.z = Mathf.Lerp(temp.z, -InputManager.Instance.horizontal * 10, 0.5f);
        temp.x += 5f;
        temp.z += 5f;

        worldObject.localEulerAngles = temp;

        // Debug.Log(temp);
    }
}
