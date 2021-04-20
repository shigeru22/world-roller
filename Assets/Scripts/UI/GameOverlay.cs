using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverlay : MonoBehaviour
{
    [SerializeField] Text timeSeconds;
    [SerializeField] Text miliSeconds;
    [SerializeField] Text coinCounter;
    [SerializeField] Text starCounter;
    [SerializeField] GameObject hyperspeedMode;

    void Start()
    {
        if (!GameManager.Instance.hyperspeedMode) hyperspeedMode.SetActive(false);
    }

    void Update()
    {
        int seconds = (int)Mathf.Floor(GameManager.Instance.timer);
        int miliseconds = (int)Mathf.Floor((GameManager.Instance.timer * 10f) % 10f);

        timeSeconds.text = seconds.ToString();
        miliSeconds.text = miliseconds.ToString();
        coinCounter.text = coinCounter.ToString();
        starCounter.text = starCounter.ToString();
    }
}
