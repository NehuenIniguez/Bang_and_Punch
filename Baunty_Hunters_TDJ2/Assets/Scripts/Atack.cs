using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    [SerializeField] private Transform ControladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    private bool esIzquierda = false;
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private AudioClip pega;

    private void Start() 
    {
      animator = GetComponent<Animator>();
      audioSource = GetComponent<AudioSource>();
    }

    private void Update() 
    {
      if (tiempoSiguienteAtaque > 0)
      {
        tiempoSiguienteAtaque -= Time.deltaTime;
      }
      if (Input.GetKeyDown(KeyCode.A) && !esIzquierda)
        {    
         transform.Rotate(0, -180, 0);
         esIzquierda = true;
        // También rotar manualmente el ControladorGolpe y otros objetos
         ControladorGolpe.Rotate(-180, -180, 0); // Esto es solo si el ControladorGolpe necesita rotación manual
        }
        if(Input.GetKeyDown(KeyCode.D) && esIzquierda)
        {
            esIzquierda = false;
            transform.Rotate(0, 180, 0);
            ControladorGolpe.Rotate(180, 180, 0);
        }

      if ( Input.GetButtonDown("Jump") && tiempoSiguienteAtaque<=0)
      {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
      }
    }
    public void Golpe()
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
        if (collisionador.CompareTag("Palanca"))
        {
          collisionador.transform.GetComponent<Palanca>().Destructor(true);
        }
        if (collisionador.CompareTag("Pincho"))
        {
          collisionador.transform.GetComponent<Pincho>().DestruirPincho();
            
        }
        
        Debug.Log(collisionador);
        animator.SetTrigger("Atack"); 
        audioSource.PlayOneShot(pega);
      }
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControladorGolpe.position, radioGolpe);    
    }
}
