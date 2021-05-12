using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool paused;

    void Update()
    {
        if(InputManager.Instance.pause)
        {
            if(!paused)
            {
                paused = true;
                GameManager.Instance.PauseGameplay();
                // show pause menu
            }
            else
            {
                paused = false;
                GameManager.Instance.ResumeGameplay();
                // hide pause menu
            }
        }
    }
}