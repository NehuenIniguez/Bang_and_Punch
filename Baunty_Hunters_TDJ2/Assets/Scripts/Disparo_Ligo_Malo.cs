using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Ligo_Malo : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;
    [SerializeField] private GameObject bala;
    private Animator animator;
    private bool esIzquierda = false;

    private void Start() {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //dispara
            Disparo();
        }
        if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("Dispara",false);
        }
        if (Input.GetKeyDown(KeyCode.A) && !esIzquierda)
        {
            transform.Rotate(0, -180, 0);

            ControladorDisparo.Rotate(-180, 0, 0);

            esIzquierda = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && esIzquierda)
        {
            transform.Rotate(0, 180, 0);

            ControladorDisparo.Rotate(180, 0, 0);

            esIzquierda = false;
        }


    }
    private void Disparo()
    {
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
        animator.SetBool("Dispara",true);
    }
    
}
