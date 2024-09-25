using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;
    //[SerializeField] private GameObject efectoMuerte;

    public void TomarDaño (float daño)
    {
        vida -= daño;
        if (vida<=0)
        {
            muerte();
        }
    }
    
    private void muerte()
    {
        Destroy(gameObject);
    }
}
