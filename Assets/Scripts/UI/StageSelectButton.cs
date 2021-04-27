using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField] StageSelectButtonTypes type;

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
                // trigger close animation
                MainMenuManager.Instance.canvasDetector.SwitchTarget(MainMenuTypes.Main);
                MainMenuManager.Instance.RunAnimation("ExitStageSelect", 0.5f);
            }
            else if (type.Equals(StageSelectButtonTypes.Previous))
            {
                // animate left
            }
            else if (type.Equals(StageSelectButtonTypes.Next))
            {
                // animate right
            }
            else if (type.Equals(StageSelectButtonTypes.Stage))
            {
                // if stage in center (selected), start, else select and animate to it
            }
            else if (type.Equals(StageSelectButtonTypes.OK))
            {
                // start
            }
            else Debug.LogError("Unknown button type.");
        }
    }
}