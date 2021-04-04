using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    private static UserDataManager instance;
    public static UserDataManager Instance { get { return instance; } }

    private SaveData _data;
    public SaveData data { get { return _data; } }

    private static readonly string dataPath = $"{Application.persistentDataPath}/userdata.json";

    void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // check if file doesn't exist
        if(!File.Exists(dataPath))
        {
            _data = new SaveData();

            // append default settings
            int len = _data.stages.Length;
            for(int i = 0; i < len; i++)
            {
                _data.stages[i].score = 0;
                _data.stages[i].stars = 0;
                _data.stages[i].coins = 0;
            }
            _data.options.masterVolume = 1f;
            _data.options.bgmVolume = 1f;
            _data.options.sfxVolume = 1f;
            _data.options.leftRotateButton = KeyCode.Q;
            _data.options.rightRotateButton = KeyCode.E;

            SaveData();
        }

        // load data
        LoadData();
    }

    public void SaveData()
    {
        using (StreamWriter writer = new StreamWriter(File.Open(dataPath, FileMode.Create)))
        {
            writer.Write(JsonUtility.ToJson(_data));
        }
    }

    public void LoadData()
    {
        using (StreamReader reader = new StreamReader(File.Open(dataPath, FileMode.Open)))
        {
            _data = JsonUtility.FromJson<SaveData>(reader.ReadLine());
        }
    }

    public void SetStageScore(int stage, int score)
    {
        _data.stages[stage].score = score;
    }

    public void SetStageStars(int stage, int stars)
    {
        _data.stages[stage].stars = stars;
    }

    public void SetStageCoins(int stage, int coins)
    {
        _data.stages[stage].coins = coins;
    }

    public void SetMasterVolume(float target)
    {
        _data.options.masterVolume = target;
        if (_data.options.masterVolume > 1f) _data.options.masterVolume = 1f;
    }

    public void SetBgmVolume(float target)
    {
        _data.options.bgmVolume = target;
        if (_data.options.bgmVolume > 1f) _data.options.bgmVolume = 1f;
    }

    public void SetSfxVolume(float target)
    {
        _data.options.sfxVolume = target;
        if (_data.options.sfxVolume > 1f) _data.options.sfxVolume = 1f;
    }
}