using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioMixerGroup BGMMixer, SFXMixer;
    float sfx, bgm;

    AudioSource background, sound;

    void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void LoadAudioSettings()
    {
        bgm = UserDataManager.Instance.data.options.bgmVolume;
        sfx = UserDataManager.Instance.data.options.sfxVolume;

        if(bgm > 0f) mixer.SetFloat("BGM", Mathf.Log(bgm) * 20f);
        else mixer.SetFloat("BGM", -80f);

        if(sfx > 0f) mixer.SetFloat("SFX", Mathf.Log(sfx) * 20f);
        else mixer.SetFloat("SFX", -80f);
    }

    void Update()
    {
        float bgm = UserDataManager.Instance.data.options.bgmVolume;
        float sfx = UserDataManager.Instance.data.options.sfxVolume;

        if(this.bgm != bgm)
        {
            if (bgm > 0f) mixer.SetFloat("BGM", Mathf.Log(bgm) * 20f);
            else mixer.SetFloat("BGM", -80f);
            this.bgm = bgm;
        }
        
        if(this.sfx != sfx)
        {
            if (sfx > 0f) mixer.SetFloat("SFX", Mathf.Log(sfx) * 20f);
            else mixer.SetFloat("SFX", -80f);
            this.sfx = sfx;
        }
    }

    public void PlayMusic(AudioSource source)
    {
        if(background != null) background.Stop();
        background = source;
        background.outputAudioMixerGroup = BGMMixer;
        background.loop = true;
        background.Play();
    }

    public void PlaySound(AudioSource source)
    {
        if(sound != null) sound.Stop();
        sound = source;
        sound.outputAudioMixerGroup = SFXMixer;
        sound.loop = false;
        sound.Play();
    }
}