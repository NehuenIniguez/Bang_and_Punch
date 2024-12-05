using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp2: MonoBehaviour
{
    private int puntos = 0;
    private AudioSource audioSource;
    [SerializeField] private float curar;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.gameObject.CompareTag("PlayerTwo") || other.gameObject.CompareTag("Player") )
        {
            other.gameObject.transform.GetComponent<Vida_PJ>().CurarVida(curar);
            Puntaje();
            audioSource.Play();
            Destroy(gameObject);
        }
    }
    public void Puntaje()
    {
        puntos = puntos + 1 ;
    }
}
