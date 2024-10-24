using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Ligo_Malo : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;

    [SerializeField] private GameObject bala;
    
    private bool esIzquierda = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //dispara
            Disparo();
        }
        if (Input.GetKeyDown(KeyCode.A) && !esIzquierda)
        {
            transform.Rotate(-180, -180, 0);
            ControladorDisparo.Rotate(-180, -180, 0);
            esIzquierda = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && esIzquierda)
        {
            transform.Rotate(0, 180, 0);
            ControladorDisparo.Rotate(180, 180, 0);
            esIzquierda = false;
        }


    }
    private void Disparo()
    {
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}
