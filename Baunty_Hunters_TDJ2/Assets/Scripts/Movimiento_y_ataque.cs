using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_y_ataque : MonoBehaviour
{
    public float salto = 1;
     
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
           // gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.transform.Translate(10f* Time.deltaTime,0,0);
        }
        if (Input.GetKey("left"))
        {
            gameObject.transform.Translate(10f* Time.deltaTime,0,0);
        }
        
    }
    private void Update() {
        if (Input.GetKeyDown("up") && salto <2) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,400f));
            salto = salto + 1;
            Debug.Log(salto);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            salto = 0; // Resetea el contador de saltos al tocar el suelo
        }
    }
}
