using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    private KeyCode _leftRotateButton;
    private KeyCode _rightRotateButton;
    private float _horizontal;
    private float _vertical;
    private bool _left;
    private bool _right;

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

    public bool left { get { return _left; } }
    public bool right { get { return _right; } }

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
        _left = Input.GetKeyDown(_leftRotateButton);
        _right = Input.GetKeyDown(_rightRotateButton);
    }

    void LoadInputSettings()
    {

    }

    public void SetLeftRotateButton(KeyCode target) { _leftRotateButton = target; }
    public void SetRightRotateButton(KeyCode target) { _rightRotateButton = target; }
}
