using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Movimiento_y_ataque : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private AudioClip saltarin;
    private Rigidbody2D rb2d;
    public bool sePuedeMover = true;
    [SerializeField] private Vector2 velocidadRebte;
    [SerializeField] private float tiempoRetroceso;
    
    public float salto = 1;
     private void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
     }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (sePuedeMover)
        {
            if (Input.GetKey("right"))
            {
                gameObject.transform.Translate(8f* Time.deltaTime,0,0);
                animator.SetBool("Derecha", true );   
            }

            if (Input.GetKey("left"))
            {
                gameObject.transform.Translate(8f* Time.deltaTime,0,0);
                animator.SetBool("Derecha", true );
            }

            if (Input.GetKeyUp("right"))
            {   
                animator.SetBool("Derecha", false);
            }

            if( Input.GetKeyUp("left"))
            {
                animator.SetBool("Derecha", false);
            }
        }
    }
    private void Update() 
    {
        if (Input.GetKeyDown("up") && salto <2) 
        {
            rb2d.AddForce(new Vector2(0, 400f));
            salto = salto + 1;
            Debug.Log(salto);
            audioSource.PlayOneShot(saltarin);
            animator.SetBool("Salta", true);
        }
        if (Input.GetKeyUp("up"))
        {
            animator.SetBool("Salta", false);
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
            salto = 0; // Resetea el contador de saltos al tocar el suelo
        }
        if(collision.gameObject.CompareTag("Agua"))
        {
            SceneManager.LoadScene("GameOverCoop");
        }
        if (collision.gameObject.CompareTag("Bala") || collision.gameObject.CompareTag("Enemigo")) // Reemplaza "ObjetoEspecifico" con el tag del objeto que quieres
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
