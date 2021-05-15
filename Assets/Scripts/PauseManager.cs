using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    private static PauseManager instance;

    public static PauseManager Instance { get { return instance; } }

    [SerializeField] Animator pauseObject;
    [SerializeField] Button pauseButton;
    [SerializeField] Button[] pauseMenus;

    [HideInInspector] public bool blocked;

    void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        SetPauseMenuInteractivity(false);
        blocked = false;
    }

    void Update()
    {
        if (InputManager.Instance.pause) TogglePause();
    }

    void SetPauseMenuInteractivity(bool target)
    {
        foreach (Button button in pauseMenus) button.interactable = target;
    }

    public void TogglePause()
    {
        if(!blocked)
        {
            blocked = true;
            if (!GameManager.Instance.isPaused)
            {
                GameManager.Instance.SetPausedStatus(true);
                GameManager.Instance.PauseGameplay();
                pauseButton.interactable = false;
                SetPauseMenuInteractivity(true);
            }
            else
            {
                GameManager.Instance.SetPausedStatus(false);
                GameManager.Instance.ResumeGameplay();
                pauseButton.interactable = true;
                SetPauseMenuInteractivity(false);
            }
            pauseObject.SetTrigger("Pause");
        }
    }
}