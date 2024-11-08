using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Ligo : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;

    [SerializeField] private GameObject bala;
    private bool esIzquierda = false;
    private AudioSource audioSource;
    [SerializeField] private AudioClip disparo;
    private Animator animator;
    private void Start() {
        audioSource = GetComponent <AudioSource>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.Return))
        {
            animator.SetBool("Dispara", true);
            //dispara
            Disparo();
            audioSource.PlayOneShot(disparo);
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            animator.SetBool("Dispara", false);
        }
        if (Input.GetKey("right") && esIzquierda)
        {
            transform.Rotate(0, 180, 0);
            
            ControladorDisparo.Rotate(180, 0, 0);
            esIzquierda = false;
        }
        if (Input.GetKey("left")&& !esIzquierda)
        {
            transform.Rotate(0, -180, 0);
            
            ControladorDisparo.Rotate(-180, 0, 0);
            esIzquierda = true;
        }
    }
    private void Disparo()
    {
        
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}
