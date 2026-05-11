using UnityEngine;

[RequireComponent(typeof(Collider))] 
public class AudioSurface : MonoBehaviour
{
    [Tooltip("¿Qué tipo de suelo es este objeto?")]
    [SerializeField] private FootStepManager.SurfaceType surface = FootStepManager.SurfaceType.GRASS;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FootStepManager.Surface = surface;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FootStepManager.Surface = surface;
        }
    }
}