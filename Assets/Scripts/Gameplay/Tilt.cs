using UnityEngine;

public class Tilt : MonoBehaviour
{
    [SerializeField] float tiltSpeed;

    void Update()
    {
        float horizontal, vertical, tilt;

        if (GameManager.Instance.isPlaying)
        {
            if (InputManager.Instance.damp) tilt = 40f;
            else tilt = 20f;
            if (GameManager.Instance.worldRotation == 1)
            {
                horizontal = -InputManager.Instance.vertical * tilt;
                vertical = -InputManager.Instance.horizontal * tilt;
            }
            else if (GameManager.Instance.worldRotation == 2)
            {
                horizontal = InputManager.Instance.horizontal * tilt;
                vertical = -InputManager.Instance.vertical * tilt;
            }
            else if (GameManager.Instance.worldRotation == 3)
            {
                // 90
                horizontal = InputManager.Instance.vertical * tilt;
                vertical = InputManager.Instance.horizontal * tilt;
            }
            else
            {
                horizontal = -InputManager.Instance.horizontal * tilt;
                vertical = InputManager.Instance.vertical * tilt;
            }
        }
        else
        {
            horizontal = 0f;
            vertical = 0f;
        }

        Quaternion target = Quaternion.Euler(vertical, 0, horizontal);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * tiltSpeed);
    }
}
