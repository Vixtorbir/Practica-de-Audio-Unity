using UnityEngine;
using UnityEngine.Audio; 

public class FootStepManager : MonoBehaviour
{
    public enum SurfaceType { GRASS, WOOD, ROAD, ROCK, WATER };
    public static SurfaceType Surface = SurfaceType.GRASS;

    [System.Serializable]
    public class SurfaceFootstep
    {
        public SurfaceType m_Surface;

        [Header("Audio Random Containers")]
        public AudioResource walkContainer;
        public AudioResource runContainer;
    }

    [Header("Configuración")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private SurfaceFootstep[] m_FootstepsSurfaces;

    public void PlayWalkStep()
    {
        ReproducirContenedor(false); 
    }

    public void PlayRunStep()
    {
        ReproducirContenedor(true); 
    }

    private void ReproducirContenedor(bool isRunning)
    {
        if (m_AudioSource == null) return;

        foreach (var surfaceGroup in m_FootstepsSurfaces)
        {
            if (surfaceGroup.m_Surface == Surface)
            {
                AudioResource resourceToPlay = isRunning ? surfaceGroup.runContainer : surfaceGroup.walkContainer;

                if (resourceToPlay != null)
                {
                    m_AudioSource.resource = resourceToPlay;
                    m_AudioSource.Play();
                }
                break;
            }
        }
    }
}