using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigos : MonoBehaviour
{
    [SerializeField] private Transform Disparo_Enemigo;
    [SerializeField] private GameObject Pincho;
    [SerializeField] private float tiempoEntreDisparos;  // Tiempo de espera entre disparos
     private AudioSource audioSource;
    [SerializeField] private AudioClip disparoPincho;

    private void Start()
    {
        // Inicia la corrutina de disparo en el inicio
        StartCoroutine(DispararConIntervalo());
        audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator DispararConIntervalo()
    {
        // Bucle infinito para que dispare continuamente
        while (true)
        {
            EnemigoDisparo();  // Llama al método de disparo
            yield return new WaitForSeconds(tiempoEntreDisparos);  // Espera el tiempo especificado antes del próximo disparo
            audioSource.PlayOneShot(disparoPincho);
        }
    }

    private void EnemigoDisparo()
    {
        Instantiate(Pincho, Disparo_Enemigo.position, Disparo_Enemigo.rotation);
      
    }
}
