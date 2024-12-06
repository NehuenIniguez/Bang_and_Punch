using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnoDeVida : MonoBehaviour
{
     private new Renderer renderer;
    
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
     public void ActualizarVida( float nuevaVida)
    {
        if (nuevaVida == 1)
        {
           renderer.enabled = true;
        }
        if (nuevaVida == 2)
        {
           renderer.enabled = false;
        }
        if (nuevaVida == 3)
        {
           renderer.enabled = false;
        }
    }

}