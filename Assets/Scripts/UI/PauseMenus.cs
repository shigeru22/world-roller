using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenus : MonoBehaviour
{
    [SerializeField] PauseMenuTypes buttonType;

    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if(!OverlayManager.Instance.blocked)
        {
            if(buttonType == PauseMenuTypes.Resume)
            {
                OverlayManager.Instance.TogglePause();
            }
            else if(buttonType == PauseMenuTypes.Retry)
            {
                GameManager.Instance.ResumeGameplay();
                GameManager.Instance.ResetAllStatus();
                OverlayManager.Instance.DestroyObject();
                SceneSwitcher.SwitchScene(GameManager.Instance.stageNumber);
            }
            else if(buttonType == PauseMenuTypes.Exit)
            {
                GameManager.Instance.ResumeGameplay();
                GameManager.Instance.ResetAllStatus();
                OverlayManager.Instance.DestroyObject();
                SceneSwitcher.SwitchScene(Scenes.MainMenu);
            }
            else
            {
                Debug.LogError("Unknown button type.");
            }

            AudioManager.Instance.PlaySound(AudioStore.Click);
        }
    }
}
