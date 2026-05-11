using UnityEngine;

public class SprintLoopAudio : MonoBehaviour
{
    [Header("Altavoz del Loop")]
    public AudioSource sprintAudioSource;

    [Header("Ajustes de Volumen")]
    public float maxVolume = 0.8f;  
    public float minVolume = 0f;    

    [Header("Ajustes de Pitch")]
    public float maxPitch = 1.3f;   
    public float minPitch = 0.8f;   

    [Header("Velocidad de Transición")]
    public float fadeSpeed = 3f;    

    void Start()
    {
        if (sprintAudioSource != null)
        {
            sprintAudioSource.loop = true;
            sprintAudioSource.volume = minVolume;
            sprintAudioSource.pitch = minPitch;

            if (!sprintAudioSource.isPlaying)
            {
                sprintAudioSource.Play();
            }
        }
    }

    void Update()
    {
        if (sprintAudioSource == null) return;

        bool isRunning = Input.GetKey(KeyCode.LeftShift) &&
                         (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
                          Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));

        float targetVolume = isRunning ? maxVolume : minVolume;
        float targetPitch = isRunning ? maxPitch : minPitch;

        sprintAudioSource.volume = Mathf.Lerp(sprintAudioSource.volume, targetVolume, Time.deltaTime * fadeSpeed);
        sprintAudioSource.pitch = Mathf.Lerp(sprintAudioSource.pitch, targetPitch, Time.deltaTime * fadeSpeed);
    }
}