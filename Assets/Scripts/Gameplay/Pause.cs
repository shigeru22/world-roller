using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    void Update()
    {
        if (InputManager.Instance.pause) PauseGameplay();
    }

    public static void PauseGameplay()
    {
        if (!GameManager.Instance.isPaused)
        {
            GameManager.Instance.SetPausedStatus(true);
            GameManager.Instance.PauseGameplay();
            // show pause menu
        }
        else
        {
            GameManager.Instance.SetPausedStatus(false);
            GameManager.Instance.ResumeGameplay();
            // hide pause menu
        }
    }
}