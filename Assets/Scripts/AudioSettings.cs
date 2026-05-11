using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    public static AudioSettings Instance { get; private set; }

    private const string MASTER_VOLUME_PARAM = "MASTER_VOLUME";
    private const string MUSIC_VOLUME_PARAM = "MUSIC_VOLUME";
    private const string AMBIENCE_VOLUME_PARAM = "AMBS_VOLUME";
    private const string SFX_VOLUME_PARAM = "SFX_VOLUME";

    [Header("Referencias del Mixer")]
    [SerializeField] private AudioMixer m_Mixer;
    [SerializeField] private AudioMixerSnapshot m_DefaultSnapshot;

    [Header("Estados / Snapshots")]
    [Tooltip("Orden: 0:Gameplay, 1:Pause, 2:Underwater, 3:Cave")]
    [SerializeField] private AudioMixerSnapshot[] m_Snapshots;

    [Header("Interfaz de Pausa (Opcional)")]
    [SerializeField] private GameObject menuPausaUI;

    private float m_MasterVolume = 1;
    private float m_MusicVolume = 1;
    private float m_SFXVolume = 1;
    private float m_AmbienceVolume = 1;

    private bool isPaused = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public enum AudioState
    {
        GAMEPLAY = 0,
        PAUSE_MENU = 1,
        UNDERWATER = 2,
        CAVE = 3
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void SetMasterVolume(float volume)
    {
        m_MasterVolume = Mathf.Clamp01(volume);
        m_Mixer.SetFloat(MASTER_VOLUME_PARAM, Mathf.Log10(Mathf.Max(0.0001f, m_MasterVolume)) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        m_MusicVolume = Mathf.Clamp01(volume);
        m_Mixer.SetFloat(MUSIC_VOLUME_PARAM, Mathf.Log10(Mathf.Max(0.0001f, m_MusicVolume)) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        m_SFXVolume = Mathf.Clamp01(volume);
        m_Mixer.SetFloat(SFX_VOLUME_PARAM, Mathf.Log10(Mathf.Max(0.0001f, m_SFXVolume)) * 20);
    }

    public void SetAmbienceVolume(float volume)
    {
        m_AmbienceVolume = Mathf.Clamp01(volume);
        m_Mixer.SetFloat(AMBIENCE_VOLUME_PARAM, Mathf.Log10(Mathf.Max(0.0001f, m_AmbienceVolume)) * 20);
    }


    public void SetCurrentSnapshot(AudioState state, float duration)
    {
        if (state == AudioState.GAMEPLAY)
            m_DefaultSnapshot.TransitionTo(duration);
        else
            m_Snapshots[(int)state].TransitionTo(duration);
    }


    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; 

        SetCurrentSnapshot(AudioState.PAUSE_MENU, 1.0f);

        if (menuPausaUI != null) menuPausaUI.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; 

        SetCurrentSnapshot(AudioState.GAMEPLAY, 0.5f);

        if (menuPausaUI != null) menuPausaUI.SetActive(false);
    }
}