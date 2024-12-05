using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Pinchos : MonoBehaviour
{
    [SerializeField] private float vidaPinchos;
    [SerializeField] private GameObject efectoMuerte;
   

    public void TomarDaño (float Daño)
    {
        vidaPinchos -= Daño;
        if (vidaPinchos<=0)
        {
            Muerte();
        }
    }
    
    private void Muerte()
    {
        Destroy(gameObject);
    }
}
