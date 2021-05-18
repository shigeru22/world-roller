using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField] StageSelectButtonTypes type;
    [SerializeField] int stageIndex; // used only for stage button

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if(MainMenuManager.Instance.isSelectingEnabled)
        {
            if (type.Equals(StageSelectButtonTypes.Close))
            {
                MainMenuManager.Instance.canvasDetector.SwitchTarget(MainMenuTypes.Main);
                MainMenuManager.Instance.RunAnimation("ExitStageSelect", 0.5f);
            }
            else if (type.Equals(StageSelectButtonTypes.Previous))
            {
                MainMenuManager.Instance.StageLeft();
            }
            else if (type.Equals(StageSelectButtonTypes.Next))
            {
                MainMenuManager.Instance.StageRight();
            }
            else if (type.Equals(StageSelectButtonTypes.Stage))
            {
                // TODO: fix bug for randomly clicking on image that doesn't respond
                MainMenuManager.Instance.SetStage(stageIndex);
            }
            else if (type.Equals(StageSelectButtonTypes.OK))
            {
                MainMenuManager.Instance.StartStage();
            }
            else Debug.LogError("Unknown button type.");
        }
    }
}