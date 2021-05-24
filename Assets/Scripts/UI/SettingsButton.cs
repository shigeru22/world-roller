using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] OptionButtonTypes type;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if(MainMenuManager.Instance.isSelectingEnabled)
        {
            if (type.Equals(OptionButtonTypes.Close))
            {
                // trigger close animation
                UserDataManager.Instance.SaveData();
                MainMenuManager.Instance.canvasDetector.SwitchTarget(MainMenuTypes.Main);
                MainMenuManager.Instance.RunAnimation("ExitOptions", 0.5f);
            }
            else if (type.Equals(OptionButtonTypes.MusicDecrease)) IncreaseVolume(VolumeTypes.Music, -0.1f);
            else if (type.Equals(OptionButtonTypes.MusicIncrease)) IncreaseVolume(VolumeTypes.Music, 0.1f);
            else if (type.Equals(OptionButtonTypes.SFXDecrease)) IncreaseVolume(VolumeTypes.SFX, -0.1f);
            else if (type.Equals(OptionButtonTypes.SFXIncrease)) IncreaseVolume(VolumeTypes.SFX, 0.1f);
            else Debug.LogError("Unknown button type.");

            AudioManager.Instance.PlaySound(AudioStore.Click);
        }
    }

    void IncreaseVolume(VolumeTypes type, float difference)
    {
        float temp;

        if (type.Equals(VolumeTypes.Music))
        {
            temp = UserDataManager.Instance.data.options.bgmVolume;
            temp += difference;

            if (temp < 0f) temp = 0f;
            else if (temp > 1f) temp = 1f;

            temp = Mathf.Round(temp * 10) / 10f;
            UserDataManager.Instance.SetBgmVolume(temp);
        }
        else if (type.Equals(VolumeTypes.SFX))
        {
            temp = UserDataManager.Instance.data.options.sfxVolume;
            temp += difference;

            if (temp < 0f) temp = 0f;
            else if (temp > 1f) temp = 1f;

            temp = Mathf.Round(temp * 10) / 10f;
            UserDataManager.Instance.SetSfxVolume(temp);
        }
        else Debug.LogError("Unknown volume type.");
    }
}