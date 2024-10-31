using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private GameObject efectoMuerte;
    private void OnCollisionEnter2D(Collision2D other) 
    {
          if (other.gameObject.CompareTag("PlayerTwo"))
        {
            other.gameObject.transform.GetComponent<Vida_PJ>().Daño_PJ( 20);
        }
        
    }

    public void TomarDaño (float Daño)
    {
        vida -= Daño;
        if (vida<=0)
        {
            Muerte();
        }
    }
    
    private void Muerte()
    {
        Destroy(gameObject);
    }
}
