using UnityEngine;
using UnityEngine.UI;

public class VolumeDisplay : MonoBehaviour
{
    public Text musicVolumeDisplay;
    public Text sfxVolumeDisplay;

    void Start()
    {
        musicVolumeDisplay.text = (UserDataManager.Instance.data.options.bgmVolume * 10f).ToString();
        sfxVolumeDisplay.text = (UserDataManager.Instance.data.options.sfxVolume * 10f).ToString();
    }

    private void Update()
    {
        musicVolumeDisplay.text = (UserDataManager.Instance.data.options.bgmVolume * 10f).ToString();
        sfxVolumeDisplay.text = (UserDataManager.Instance.data.options.sfxVolume * 10f).ToString();
    }
}
