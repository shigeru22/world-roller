using UnityEngine;

public class UILoader : MonoBehaviour
{
    [SerializeField] string UISceneName;

    void Start()
    {
        if (!UISceneName.Equals(string.Empty)) SceneSwitcher.AddScene(Scenes.GameOverlay);
    }
}