using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo_Ligo_Malo : MonoBehaviour
{
    [SerializeField] private Transform ControladorDisparo;

    [SerializeField] private GameObject bala;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            //dispara
            Disparo();
        }


    }
    private void Disparo()
    {
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}
