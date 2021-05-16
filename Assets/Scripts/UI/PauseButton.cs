using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PauseAction);
    }

    void PauseAction()
    {
        OverlayManager.Instance.TogglePause();
    }
}
