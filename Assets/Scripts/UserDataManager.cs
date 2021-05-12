using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    private static UserDataManager instance;
    public static UserDataManager Instance { get { return instance; } }

    private SaveData _data;

    /// <summary>
    /// Currently loaded user data (read only).
    /// Values may be changed using setter methods.
    /// </summary>
    public SaveData data { get { return _data; } }

    private static readonly string dataPath = $"{Application.persistentDataPath}/userdata.json";

    void Awake()
    {
        Debug.Log(Application.persistentDataPath);
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
                _data.stages[i].cleared = false;
                _data.stages[i].score = 0;
                _data.stages[i].stars = 0;
                _data.stages[i].coins = 0;
            }
            _data.options.masterVolume = 1f;
            _data.options.bgmVolume = 1f;
            _data.options.sfxVolume = 1f;
            _data.options.leftRotateButton = KeyCode.Q;
            _data.options.rightRotateButton = KeyCode.E;
            _data.options.pauseButton = KeyCode.Escape;

            SaveData();
        }

        // load data
        LoadData();
    }

    /// <summary>
    /// Saves user data.
    /// </summary>
    public void SaveData()
    {
        using (StreamWriter writer = new StreamWriter(File.Open(dataPath, FileMode.Create)))
        {
            writer.Write(JsonUtility.ToJson(_data, true));
        }
    }

    /// <summary>
    /// Loads user data.
    /// </summary>
    public void LoadData()
    {
        using (StreamReader reader = new StreamReader(File.Open(dataPath, FileMode.Open)))
        {
            _data = JsonUtility.FromJson<SaveData>(reader.ReadLine());
        }
    }

    /// <summary>
    /// Sets target stage's cleared status.
    /// </summary>
    /// <param name="stage">Target stage (from 1 to total stages)</param>
    /// <param name="target">Status to be set.</param>
    public void SetStageClearedStatus(int stage, bool target)
    {
        _data.stages[stage - 1].cleared = target;
    }

    /// <summary>
    /// Sets target stage's score.
    /// </summary>
    /// <param name="stage">Target stage (from 1 to total stages)</param>
    /// <param name="score">Score to be set.</param>
    public void SetStageScore(int stage, int score)
    {
        _data.stages[stage - 1].score = score;
        if (_data.stages[stage - 1].score < 0) _data.stages[stage - 1].score = 0;
    }

    /// <summary>
    /// Sets target stage's stars count.
    /// </summary>
    /// <param name="stage">Target stage (from 1 to total stages)</param>
    /// <param name="stars">Number of stars to be set.</param>
    public void SetStageStars(int stage, int stars)
    {
        _data.stages[stage].stars = stars;
        if (_data.stages[stage].stars > 3) _data.stages[stage].stars = 3;
        else if (_data.stages[stage].stars < 0) _data.stages[stage].stars = 0;
    }

    /// <summary>
    /// Sets target stage's coins count.
    /// </summary>
    /// <param name="stage">Target stage (from 1 to total stages)</param>
    /// <param name="coins">Number of coins to be set.</param>
    public void SetStageCoins(int stage, int coins)
    {
        _data.stages[stage].coins = coins;
        if (_data.stages[stage].coins < 0) _data.stages[stage].coins = 0;
    }

    /// <summary>
    /// Sets master volume.
    /// </summary>
    /// <param name="target">Target volume in decimals.</param>
    public void SetMasterVolume(float target)
    {
        _data.options.masterVolume = target;
        if (_data.options.masterVolume > 1f) _data.options.masterVolume = 1f;
        else if (_data.options.masterVolume < 0f) _data.options.masterVolume = 0f;
    }

    /// <summary>
    /// Sets BGM volume.
    /// </summary>
    /// <param name="target">Target volume in decimals.</param>
    public void SetBgmVolume(float target)
    {
        _data.options.bgmVolume = target;
        if (_data.options.bgmVolume > 1f) _data.options.bgmVolume = 1f;
        else if (_data.options.bgmVolume < 0f) _data.options.bgmVolume = 0f;
    }

    /// <summary>
    /// Sets SFX volume.
    /// </summary>
    /// <param name="target">Target volume in decimals.</param>
    public void SetSfxVolume(float target)
    {
        _data.options.sfxVolume = target;
        if (_data.options.sfxVolume > 1f) _data.options.sfxVolume = 1f;
        else if (_data.options.sfxVolume < 0f) _data.options.sfxVolume = 0f;
    }
}