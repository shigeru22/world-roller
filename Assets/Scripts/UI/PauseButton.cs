using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PauseAction);
    }

    void PauseAction()
    {
        Pause.PauseGameplay();
    }
}
