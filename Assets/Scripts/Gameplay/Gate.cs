using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] StatusCube statusCube;
    [SerializeField] AudioSource sfx;

    public bool entered { get; private set; }

    void Start()
    {
        entered = false;
    }

    public void EnterGate()
    {
        entered = true;
        statusCube.ChangeColor();
        sfx.Play();
    }
}
