using UnityEngine;

public class StatusCube : MonoBehaviour
{
    Renderer cube;
    Light lighting;

    void Start()
    {
        cube = GetComponent<Renderer>();
        lighting = GetComponent<Light>();
        lighting.enabled = false;
    }

    public void ChangeColor()
    {
        cube.material.color = Color.yellow;
        lighting.enabled = true;
    }
}