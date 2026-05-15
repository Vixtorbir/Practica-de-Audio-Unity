using UnityEngine;

public class SnapshotTrigger : MonoBehaviour
{
    [Header("Configuración de Estados")]
    public AudioSettings.AudioState zonaState = AudioSettings.AudioState.UNDERWATER;
    public float tiempoTransicion = 1.5f;

    public AudioSource splashSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSettings.Instance.SetCurrentSnapshot(zonaState, tiempoTransicion);

            if (splashSound != null)
            {
                splashSound.PlayOneShot(splashSound.clip);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSettings.Instance.SetCurrentSnapshot(AudioSettings.AudioState.GAMEPLAY, tiempoTransicion);
        }
    }
}