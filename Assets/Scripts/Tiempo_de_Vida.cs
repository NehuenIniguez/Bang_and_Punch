using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempo_de_Vida : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida;
   private void Start()
    {
     Destroy(gameObject, tiempoDeVida);   
    }

}
