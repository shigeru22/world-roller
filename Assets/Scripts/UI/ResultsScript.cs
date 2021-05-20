using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScript : MonoBehaviour
{
    public int stage;
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
    }

    void RetryAction()
    {
        SceneSwitcher.SwitchScene(stage);
    }

    void NextAction()
    {
        if (stage < SceneSwitcher.totalScenes - 2)
        {
            int target = stage + 1;

            GameManager.Instance.SetStageNumber(target);
            SceneSwitcher.SwitchScene((Scenes)target);
        }
        else nextButton.interactable = false;
    }
}
