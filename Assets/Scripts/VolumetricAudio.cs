using UnityEngine;

[RequireComponent(typeof(Collider))]
public class VolumetricAudio : MonoBehaviour
{
    [Tooltip("El Audio Source que reproducirá el agua")]
    public AudioSource m_AudioSource;

    private Transform playerTransform;
    private Collider lakeCollider;
    private Transform audioMover; // El objeto invisible que moveremos

    void Start()
    {
        // 1. Buscamos a Shadow (asegúrate de que tiene el Tag "Player")
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) playerTransform = player.transform;

        lakeCollider = GetComponent<Collider>();

        audioMover = new GameObject("Altavoz_Volumetrico").transform;
        audioMover.SetParent(transform);

        if (m_AudioSource == null) m_AudioSource = GetComponent<AudioSource>();

        AudioSource newSource = audioMover.gameObject.AddComponent<AudioSource>();
        newSource.clip = m_AudioSource.clip;
        newSource.outputAudioMixerGroup = m_AudioSource.outputAudioMixerGroup;
        newSource.spatialBlend = 1f;
        newSource.rolloffMode = AudioRolloffMode.Linear;
        newSource.minDistance = m_AudioSource.minDistance;
        newSource.maxDistance = m_AudioSource.maxDistance;
        newSource.loop = true;
        newSource.playOnAwake = true;
        newSource.volume = m_AudioSource.volume;

        newSource.Play();

        m_AudioSource.enabled = false;
    }

    void Update()
    {
        if (playerTransform == null || lakeCollider == null) return;

        Vector3 closestPoint = lakeCollider.ClosestPoint(playerTransform.position);

        audioMover.position = closestPoint;
    }
}