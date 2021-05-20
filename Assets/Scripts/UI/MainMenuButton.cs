using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] ButtonTypes buttonType;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        Invoke(nameof(AddButtonAction), 2f);
    }

    void AddButtonAction()
    {
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if(MainMenuManager.Instance.isSelectingEnabled)
        {
            if (buttonType == ButtonTypes.Play)
            {
                // enter stage select
                MainMenuManager.Instance.canvasDetector.SwitchTarget(MainMenuTypes.StageSelect);
                MainMenuManager.Instance.RunAnimation("EnterStageSelect", 0.5f);
            }
            else if (buttonType == ButtonTypes.Options)
            {
                // enter options
                MainMenuManager.Instance.canvasDetector.SwitchTarget(MainMenuTypes.Options);
                MainMenuManager.Instance.RunAnimation("EnterOptions", 0.5f);
            }
            else if (buttonType == ButtonTypes.Credits)
            {
                // enter credits
                MainMenuManager.Instance.canvasDetector.SwitchTarget(MainMenuTypes.Credits);
            }
            else if (buttonType == ButtonTypes.Exit)
            {
                // exit game
                Application.Quit();
            }
            else Debug.LogError("Unknown button type.");

            AudioManager.Instance.PlaySound(AudioStore.Click);
        }
    }
}
