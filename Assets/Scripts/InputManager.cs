using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance { get { return instance; } }

    private KeyCode _leftRotateButton;
    private KeyCode _rightRotateButton;
    private KeyCode _dampButton;
    private KeyCode _pauseButton;
    private float _horizontal;
    private float _vertical;
    private bool _damp;
    private bool _left;
    private bool _right;
    private bool _pause;

    /// <summary>
    /// Horizontal input axis.
    /// </summary>
    public float horizontal { get { return _horizontal; } }

    /// <summary>
    /// Vertical input axis.
    /// </summary>
    public float vertical { get { return _vertical; } }

    /// <summary>
    /// Whether damp tilting button is pressed.
    /// </summary>
    public bool damp { get { return _damp; } }

    /// <summary>
    /// Whether rotate left button is pressed.
    /// </summary>
    public bool left { get { return _left; } }

    /// <summary>
    /// Whether rotate right button is pressed.
    /// </summary>
    public bool right { get { return _right; } }

    /// <summary>
    /// Whether pause button is pressed.
    /// </summary>
    public bool pause { get { return _pause; } }

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
        _damp = Input.GetKey(_dampButton);
        _left = Input.GetKeyDown(_leftRotateButton);
        _right = Input.GetKeyDown(_rightRotateButton);
        _pause = Input.GetKeyDown(_pauseButton);
    }

    /// <summary>
    /// Loads input settings from UserDataManager singleton.
    /// Make sure the user's data has been loaded before invoking the method.
    /// </summary>
    public void LoadInputSettings()
    {
        _leftRotateButton = UserDataManager.Instance.data.options.leftRotateButton;
        _rightRotateButton = UserDataManager.Instance.data.options.rightRotateButton;
        _dampButton = UserDataManager.Instance.data.options.dampTiltingButton;
        _pauseButton = UserDataManager.Instance.data.options.pauseButton;
    }

    /// <summary>
    /// Sets the left rotate button.
    /// </summary>
    /// <param name="target">Left rotate button keycode from user's data.</param>
    public void SetLeftRotateButton(KeyCode target) { _leftRotateButton = target; }

    /// <summary>
    /// Sets the right rotate button.
    /// </summary>
    /// <param name="target">Right rotate button keycode from user's data.</param>
    public void SetRightRotateButton(KeyCode target) { _rightRotateButton = target; }

    /// <summary>
    /// Sets the damp tilting button.
    /// </summary>
    /// <param name="target">Damp tilting button from user's data.</param>
    public void SetDampTiltingButton(KeyCode target) { _dampButton = target; }

    /// <summary>
    /// Sets the pause button.
    /// </summary>
    /// <param name="target">Pause button keycode from user's data.</param>
    public void SetPauseButton(KeyCode target) { _pauseButton = target; }
}