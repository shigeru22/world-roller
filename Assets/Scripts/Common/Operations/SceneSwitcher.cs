using UnityEngine.SceneManagement;

public class SceneSwitcher
{
    public static int totalScenes { get { return SceneManager.sceneCountInBuildSettings; } }

    public static void SwitchScene(Scenes scene)
    {
        OverlayCheck();
        GameManager.Instance.ResetAllStatus();
        SceneManager.LoadScene((int)scene);
    }

    public static void SwitchScene(int sceneIndex)
    {
        OverlayCheck();
        GameManager.Instance.ResetAllStatus();
        SceneManager.LoadScene(sceneIndex);
    }

    public static void SwitchScene(string sceneName)
    {
        OverlayCheck();
        GameManager.Instance.ResetAllStatus();
        SceneManager.LoadScene(sceneName);
    }

    public static void AddScene(Scenes scene)
    {
        SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive);
    }

    public static void AddScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    static void OverlayCheck()
    {
        if (OverlayManager.Instance != null) OverlayManager.Instance.ResetStatus();
    }
}