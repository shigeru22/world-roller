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

    public void GetCounters()
    {
        // gatesCount = GameManager.Instance. // gates?
        starsCount.text = GameManager.Instance.stars.ToString();
        coinsCount.text = GameManager.Instance.coins.ToString();
        score.text = GameManager.Instance.score.ToString();
    }
}
