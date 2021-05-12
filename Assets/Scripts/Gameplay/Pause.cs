using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool paused;

    void Update()
    {
        // TODO: Change keycode from user data
        if(Input.GetKeyDown(KeyCode.Escape))
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
                GameManager.Instance.StartGameplay();
                // hide pause menu
            }
        }
    }
}