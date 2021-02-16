using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    private float _horizontal;
    private float _vertical;

    public float horizontal
    {
        get { return _horizontal; }
        private set { _horizontal = value; }
    }

    public float vertical
    {
        get { return _vertical; }
        private set { _vertical = value; }
    }

    void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
}
