using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskDetection : MonoBehaviour
{
    [SerializeField] CanvasGroup stageSelectWindow;
    [SerializeField] CanvasGroup optionsWindow;
    [SerializeField] CanvasGroup creditsWindow;

    MainMenuTypes current;
    CanvasGroup target;

    void Start()
    {
        current = MainMenuTypes.Main;
        stageSelectWindow.gameObject.SetActive(false);
        optionsWindow.gameObject.SetActive(false);
        // creditsWindow.gameObject.SetActive(false);
    }

    void Update()
    {
        if (current.Equals(MainMenuTypes.Main))
        {
            if (target != null && target.gameObject.activeSelf && target.alpha <= 0f)
            {
                target.gameObject.SetActive(false);
                target = null;
            }
        }
    }

    public void SwitchTarget(MainMenuTypes target)
    {
        if(!current.Equals(MainMenuTypes.Main))
        {
            if (target.Equals(MainMenuTypes.Main))
            {
                if (current.Equals(MainMenuTypes.StageSelect)) this.target = stageSelectWindow;
                else if (current.Equals(MainMenuTypes.Options)) this.target = optionsWindow;
                else if (current.Equals(MainMenuTypes.Credits)) this.target = creditsWindow;
                current = MainMenuTypes.Main;
                // Debug.Log(this.target.gameObject.name);
            }
            else Debug.LogError("Can't open other section while this section is still open.");
        }
        else
        {
            current = target;
            if (target.Equals(MainMenuTypes.StageSelect)) stageSelectWindow.gameObject.SetActive(true);
            else if (target.Equals(MainMenuTypes.Options)) optionsWindow.gameObject.SetActive(true);
            else if (target.Equals(MainMenuTypes.Credits)) creditsWindow.gameObject.SetActive(true);
        }
    }
}
