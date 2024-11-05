using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Ligo_Malo : MonoBehaviour
{
    public float brinco = 0;

    private Rigidbody2D rb2d;
    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebte;
    [SerializeField] private float tiempoRetroceso;
    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
       
       if (sePuedeMover)
       { 
         if (Input.GetKey(KeyCode.D))
         {
             gameObject.transform.Translate(8f* Time.deltaTime,0,0);
         }
         if (Input.GetKey(KeyCode.A))
         {
             gameObject.transform.Translate(8f* Time.deltaTime,0,0);
          }
        }
        
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.W) && brinco <2)
        {
            //Hacemos que el salto se sume
            rb2d.AddForce(new Vector2(0, 400f));
            brinco = brinco +1;
            Debug.Log(brinco);
        }
    }
    public void Rebote(Vector2 puntoGolpe)
    {
        rb2d.velocity= new Vector2(velocidadRebte.x * puntoGolpe.x, velocidadRebte.y ) ;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            brinco = 0; // Resetea el contador de saltos al tocar el suelo
        }
        if (collision.gameObject.CompareTag("Bala") || collision.gameObject.CompareTag("Enemigo")) 
        {
            // Calcula la dirección del retroceso
            Vector2 direccionRetroceso = (transform.position - collision.transform.position).normalized;
            rb2d.AddForce(direccionRetroceso * velocidadRebte.x, ForceMode2D.Impulse);

            // Desactiva el movimiento y espera un tiempo
            StartCoroutine(DesactivarMovimiento());
        }
    }

    private IEnumerator DesactivarMovimiento()
    {
        sePuedeMover = false;
        yield return new WaitForSeconds(tiempoRetroceso);
        sePuedeMover = true;
    }
    
}
