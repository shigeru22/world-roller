using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayManager : MonoBehaviour
{
    private static OverlayManager instance;

    public static OverlayManager Instance { get { return instance; } }

    [SerializeField] Animator pauseObject;
    [SerializeField] Button pauseButton;
    [SerializeField] Button[] pauseMenus;
    [SerializeField] Animator resultsObject;
    [SerializeField] Button[] resultMenus;
    [SerializeField] ResultsScript resultsCounters;

    [HideInInspector] public bool blocked;
    bool resultShown;

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
        SetResultsMenuInteractivity(false);
        blocked = false;
        resultShown = false;
    }

    void Update()
    {
        if (InputManager.Instance.pause) TogglePause();
        if(GameManager.Instance.isCompleted && !resultShown)
        {
            ToggleResults();
            resultShown = true;
        }
    }

    void SetPauseMenuInteractivity(bool target)
    {
        foreach (Button button in pauseMenus) button.interactable = target;
    }

    void SetResultsMenuInteractivity(bool target)
    {
        foreach (Button button in resultMenus) button.interactable = target;
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

    public void ToggleResults()
    {
        // TODO: Show this after level is completed, following with button logic
        SetResultsMenuInteractivity(true);
        GameManager.Instance.SetCompleted();
        resultsCounters.GetCounters();
        resultsObject.SetTrigger("Show");
    }

    public void ResetStatus()
    {
        // Start();
        Destroy(gameObject);
    }
}