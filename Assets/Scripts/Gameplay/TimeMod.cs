using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMod : MonoBehaviour
{
    void Start()
    {
        int time = 180;

        if (GameManager.Instance.stageNumber == 4) time = 325;
        GameManager.Instance.defaultTime = time;
    }
}