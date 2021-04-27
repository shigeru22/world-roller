using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    [SerializeField] string UISceneName;

    void Start()
    {
        if (!UISceneName.Equals(string.Empty)) SceneManager.LoadSceneAsync(UISceneName, LoadSceneMode.Additive);
    }
}