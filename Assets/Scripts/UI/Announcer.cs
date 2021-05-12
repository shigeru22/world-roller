using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Announcer : MonoBehaviour
{
    [SerializeField] Animator announcerAnimator;

    void Start()
    {
        // indeed, this should be started additively
        GameManager.Instance.ResetTimer();
        announcerAnimator.SetTrigger("Start");
    }

    void StartGameplay()
    {
        // notify gamemanager to start game, unblocking its input
        GameManager.Instance.StartGameplay();
    }
}