using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Ligo : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;

    [SerializeField] private GameObject bala;
    private bool esIzquierda = false;

    
    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.RightControl))
        {
            //dispara
            Disparo();
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
