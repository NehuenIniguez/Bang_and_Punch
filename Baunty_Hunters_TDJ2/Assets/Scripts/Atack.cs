using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    [SerializeField] private Transform ControladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;

    private void Update() 
    {
      if ( Input.GetButtonDown("Fire1"))
     {
        Golpe();
     }
    }
    private void Golpe()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(ControladorGolpe.position, radioGolpe);
        foreach(Collider2D collisionador in objetos)
        {
            if (collisionador.CompareTag("Enemigo"))
            {
                collisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }
            if (collisionador.CompareTag("Pared"))
            {
                collisionador.transform.GetComponent<VidaPared>().TomarDaño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControladorGolpe.position, radioGolpe);    
    }
}
