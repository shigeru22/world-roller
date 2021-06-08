using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform hero;

    private float turnSpeed = 4.0f;
    private Transform posHero;
    private Vector3 offset;

    void Start()
    {
        posHero = hero.transform;
        offset = new Vector3(posHero.position.x, posHero.position.y + 1f, posHero.position.z + 5f);
    }

    void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = posHero.position + offset;
        transform.LookAt(posHero.position);
    }
}
