using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private static MainMenuManager instance;
    public static MainMenuManager Instance { get { return instance; } }

    [SerializeField] Animator menuAnimator;
    public MaskDetection canvasDetector;

    bool isBlocked;
    float timer;
    float duration;

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
        if (instance != null && instance != this) Destroy(gameObject);
        else instance = this;
    }

    void Start()
    {
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
}