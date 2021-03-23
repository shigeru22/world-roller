using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] ButtonTypes buttonType;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
        Invoke(nameof(AddButtonAction), 2f);
    }

    void AddButtonAction()
    {
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if (buttonType == ButtonTypes.Play)
        {
            SceneManager.LoadScene("TestScene");
        }
        else if (buttonType == ButtonTypes.Options)
        {
            // enter options
        }
        else if (buttonType == ButtonTypes.Credits)
        {
            // enter credits
        }
        else if (buttonType == ButtonTypes.Exit)
        {
            // exit game
            Application.Quit();
        }
        else Debug.LogError("Unknown button type.");
    }
}
