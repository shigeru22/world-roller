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

    public float horizontal { get { return _horizontal; } }

    public float vertical { get { return _vertical; } }

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
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _left = Input.GetKeyDown(_leftRotateButton);
        _right = Input.GetKeyDown(_rightRotateButton);
    }

    public void LoadInputSettings()
    {
        _leftRotateButton = UserDataManager.Instance.data.options.leftRotateButton;
        _rightRotateButton = UserDataManager.Instance.data.options.rightRotateButton;
    }

    public void SetLeftRotateButton(KeyCode target) { _leftRotateButton = target; }
    public void SetRightRotateButton(KeyCode target) { _rightRotateButton = target; }
}
