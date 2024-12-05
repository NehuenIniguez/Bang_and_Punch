using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour
{
    public GameObject puerta;
     private new Collider2D collider2D;
    private new Renderer renderer;
     private AudioSource audioSource;
    [SerializeField] private AudioClip seAbre;
    [SerializeField] private AudioClip palanca;
    [SerializeField] private AudioClip boton;
   private void Start() {
    audioSource = GetComponent<AudioSource>();
   }
    private void Awake() {
        collider2D = GetComponent<Collider2D>();
        renderer = GetComponent<Renderer>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Bala") ||Input.GetButtonDown("Jump") )
        {
            audioSource.PlayOneShot(boton);
            audioSource.PlayOneShot(seAbre);
            Destroy(puerta);
            
        }
    }
    public void Destructor( bool encendido)
    {
        if (encendido == true)
        {
            audioSource.PlayOneShot(palanca);
            audioSource.PlayOneShot(seAbre);
            Destroy(puerta); 
        }
    }

}
