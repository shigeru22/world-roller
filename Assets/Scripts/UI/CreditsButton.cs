using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(closeCredits);
    }

    // Update is called once per frame
    void closeCredits()
    {
        MainMenuManager.Instance.canvasDetector.SwitchTarget(MainMenuTypes.Main);
        MainMenuManager.Instance.RunAnimation("ExitCredits", 0.5f);
    }
}
