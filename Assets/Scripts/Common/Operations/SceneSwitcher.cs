using UnityEngine.SceneManagement;

public class SceneSwitcher
{
    public static void SwitchScene(Scenes scene)
    {
        SceneManager.LoadScene((int)scene);
    }

    public static void SwitchScene(string sceneName)
    {
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
}