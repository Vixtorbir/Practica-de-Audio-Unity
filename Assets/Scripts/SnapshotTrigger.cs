using UnityEngine;

public class SnapshotTrigger : MonoBehaviour
{
    [Header("Configuración de Estados")]
    public AudioSettings.AudioState zonaState = AudioSettings.AudioState.UNDERWATER;
    public float tiempoTransicion = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSettings.Instance.SetCurrentSnapshot(zonaState, tiempoTransicion);
            Debug.Log("Entrando en zona: " + zonaState);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSettings.Instance.SetCurrentSnapshot(AudioSettings.AudioState.GAMEPLAY, tiempoTransicion);
            Debug.Log("Saliendo de zona. Volviendo a Gameplay");
        }
    }
}