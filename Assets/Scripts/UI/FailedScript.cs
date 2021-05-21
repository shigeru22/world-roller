using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailedScript : MonoBehaviour
{
    [SerializeField] Button retryButton;
    [SerializeField] Button exitButton;

    Animator anim;

    public void ShowWindow()
    {
        anim = GetComponent<Animator>();
        retryButton.onClick.AddListener(RetryAction);
        exitButton.onClick.AddListener(ExitAction);
        retryButton.interactable = true;
        exitButton.interactable = true;
        retryButton.GetComponent<Image>().raycastTarget = true;
        exitButton.GetComponent<Image>().raycastTarget = true;

        anim.SetTrigger("Toggle");
    }

    void RetryAction()
    {
        SceneSwitcher.SwitchScene(GameManager.Instance.stageNumber);
        AudioManager.Instance.PlaySound(AudioStore.Click);
    }

    void ExitAction()
    {
        AudioManager.Instance.PlaySound(AudioStore.Click);
        OverlayManager.Instance.DestroyObject();
        SceneSwitcher.SwitchScene(Scenes.MainMenu);
    }
}