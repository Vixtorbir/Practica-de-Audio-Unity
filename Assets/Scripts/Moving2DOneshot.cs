using UnityEngine;

public class Moving3DOneshot : MonoBehaviour
{
    public float velocidadVuelo = 15f;
    public float tiempoEntreGraznidos = 4f;

    private AudioSource audioSource;
    private float temporizador;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        temporizador = tiempoEntreGraznidos;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * velocidadVuelo * Time.deltaTime);

        temporizador -= Time.deltaTime;
        if (temporizador <= 0f)
        {
            audioSource.PlayOneShot(audioSource.clip);
            temporizador = tiempoEntreGraznidos;
        }
    }
}