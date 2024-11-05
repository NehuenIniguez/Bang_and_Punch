using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Movimiento_y_ataque : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private AudioClip saltarin;

    
    public float salto = 1;
     private void Start() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
     }
    // Update is called once per frame
    void FixedUpdate()
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
    private void Update() 
    {
        if (Input.GetKeyDown("up") && salto <2) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,400f));
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
    }
}
