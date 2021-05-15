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
        if(!PauseManager.Instance.blocked)
        {
            if(buttonType == PauseMenuTypes.Resume)
            {
                PauseManager.Instance.TogglePause();
            }
            else if(buttonType == PauseMenuTypes.Retry)
            {
                // TODO: Add retry animation and reload scene
            }
            else if(buttonType == PauseMenuTypes.Exit)
            {
                // TODO: Add retry animation (same since transitions to black) and load main menu scene
            }
            else
            {
                Debug.LogError("Unknown button type.");
            }
        }
    }
}
