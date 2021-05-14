using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager instance;
    public static MainMenuManager Instance { get { return instance; } }

    [SerializeField] Animator menuAnimator;
    [SerializeField] Animator powerupAnimator;
    public MaskDetection canvasDetector;

    // TODO: Add more stages when done
    [SerializeField] Button[] stages;
    
    bool isBlocked;
    float timer;
    float duration;
    int selectedStage;

    public bool isSelectingEnabled
    {
        get
        {
            if (!isBlocked) return true;
            else return false;
        }
    }

    void Awake()
    {
        if (stages.Length == 0) Debug.LogError("No stages specified. Add them in the inspector.");
        
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    void Start()
    {
        selectedStage = 0;
        RunAnimation(string.Empty, 2f);
    }

    void Update()
    {
        if(isBlocked)
        {
            timer += Time.deltaTime;
            if(timer >= duration)
            {
                isBlocked = false;
                timer = 0f;
            }
        }
    }

    void SelectStage(int target)
    {
        if (target > 0)
        {
            if (selectedStage < stages.Length - 1) selectedStage++;
        }
        else if (target < 0)
        {
            if (selectedStage > 0) selectedStage--;
        }
        else Debug.LogWarning("What are you doing?");
    }

    public void RunAnimation(string animation, float pauseButtonDuration)
    {
        if(!animation.Equals(string.Empty)) menuAnimator.SetTrigger(animation);
        BlockTimer(pauseButtonDuration);
    }

    public void BlockTimer(float duration)
    {
        this.duration = duration;
        timer = 0f;
        isBlocked = true;
    }

    public void TogglePowerup()
    {
        // TODO: if open, get state and change color
        powerupAnimator.SetTrigger("Open");
    }

    public void StageRight()
    {
        SelectStage(1);
    }

    public void StageLeft()
    {
        SelectStage(-1);
    }

    public void StartStage()
    {
        // selected starts from 0, and the enum stages are from 1 to 4
        SceneSwitcher.SwitchScene((Scenes)(selectedStage + 1));
    }
}