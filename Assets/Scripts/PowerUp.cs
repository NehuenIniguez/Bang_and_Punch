using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{ 
    public Puntos puntajeManager; // Referencia al PuntajeManager
    private AudioSource audioSource;
    [SerializeField] private float curar;
    [SerializeField] private AudioClip power;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Asegurarse de que puntajeManager esté asignado
        if (puntajeManager == null)
        {
            puntajeManager = GameObject.FindObjectOfType<Puntos>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerTwo") || other.gameObject.CompareTag("Player") )
        {
            other.gameObject.transform.GetComponent<Vida_PJ>().CurarVida(curar);
            audioSource.PlayOneShot(power);
            puntajeManager.AgregarPuntos(1); // Agregar 1 punto al puntaje global
            Destroy(gameObject);
        }
    }
}
