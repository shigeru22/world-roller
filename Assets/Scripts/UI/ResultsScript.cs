using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScript : MonoBehaviour
{
    [SerializeField] Text gatesCount;
    [SerializeField] Text starsCount;
    [SerializeField] Text coinsCount;
    [SerializeField] Text score;
    [SerializeField] Button retryButton;
    [SerializeField] Button nextButton;

    public void GetCounters()
    {
        gatesCount.text = GameManager.Instance.gates.ToString();
        starsCount.text = GameManager.Instance.stars.ToString();
        coinsCount.text = GameManager.Instance.coins.ToString();
        score.text = GameManager.Instance.score.ToString();

        retryButton.onClick.AddListener(RetryAction);
        nextButton.onClick.AddListener(NextAction);

        if (GameManager.Instance.stageNumber >= SceneSwitcher.totalScenes - 2) nextButton.interactable = false;
    }

    void RetryAction()
    {
        OverlayManager.Instance.ResetStatus();
        SceneSwitcher.SwitchScene(GameManager.Instance.stageNumber);
        AudioManager.Instance.PlaySound(AudioStore.Click);
    }

    void NextAction()
    {
        int target = GameManager.Instance.stageNumber + 1;

        GameManager.Instance.SetStageNumber(target);
        OverlayManager.Instance.ResetStatus();
        AudioManager.Instance.PlaySound(AudioStore.Click);
        SceneSwitcher.SwitchScene((Scenes)target);
    }
}
