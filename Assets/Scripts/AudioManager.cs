using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    [SerializeField] AudioMixer mixer;
    [SerializeField] AudioMixerGroup BGMMixer, SFXMixer;
    float sfx, bgm;

    [SerializeField] AudioClip backgroundSource;
    [SerializeField] AudioSource background, sound;

    void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        background.outputAudioMixerGroup = BGMMixer;
        sound.outputAudioMixerGroup = SFXMixer;
        // PlayMusic(AudioStore.BGM);
    }

    void LoadAudioSettings()
    {
        bgm = UserDataManager.Instance.data.options.bgmVolume;
        sfx = UserDataManager.Instance.data.options.sfxVolume;

        if (bgm > 0f) mixer.SetFloat("BGM", Mathf.Log(bgm) * 20f);
        else mixer.SetFloat("BGM", -80f);

        if (sfx > 0f) mixer.SetFloat("SFX", Mathf.Log(sfx) * 20f);
        else mixer.SetFloat("SFX", -80f);
    }

    void Update()
    {
        float bgm = UserDataManager.Instance.data.options.bgmVolume;
        float sfx = UserDataManager.Instance.data.options.sfxVolume;

        if (this.bgm != bgm)
        {
            if (bgm > 0f) mixer.SetFloat("BGM", Mathf.Log(bgm) * 20f);
            else mixer.SetFloat("BGM", -80f);
            this.bgm = bgm;
        }

        if (this.sfx != sfx)
        {
            if (sfx > 0f) mixer.SetFloat("SFX", Mathf.Log(sfx) * 20f);
            else mixer.SetFloat("SFX", -80f);
            this.sfx = sfx;
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        background.clip = clip;
        background.outputAudioMixerGroup = BGMMixer;
        background.loop = true;
        background.Play();
    }

    public void PlayMusic(string resourcesPath)
    {
        background.clip = Resources.Load<AudioClip>(resourcesPath);
        background.loop = false;
        background.Play();
    }

    public void PlaySound(string resourcesPath)
    {
        sound.clip = Resources.Load<AudioClip>(resourcesPath);
        sound.loop = false;
        sound.Play();
    }
}