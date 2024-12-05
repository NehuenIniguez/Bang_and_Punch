using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionVida : MonoBehaviour
{
     private new Renderer renderer;
       void Start()
    {
        renderer = GetComponent<Renderer>();
    }
     public void ActualizarVida( float vidaActual)
    {
        if (vidaActual == 1)
        {
           renderer.enabled = false;
        }
        if (vidaActual == 2)
        {
           renderer.enabled = false;;
        }
        if (vidaActual == 3)
        {
           renderer.enabled = true;
        }
    }

}
