using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Ligo_Malo : MonoBehaviour
{
    public float brinco = 0;
    
    // Update is called once per frame
    void Update()
    {
        //Se agregan teclas y movimientos de las teclas 
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(10f* Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(10f* Time.deltaTime,0,0);
        }
        if (Input.GetKeyDown(KeyCode.W) && brinco <2)
        {
            //Hacemos que el salto se sume
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,400f));
            brinco = brinco +1;
            Debug.Log(brinco);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            brinco = 0; // Resetea el contador de saltos al tocar el suelo
        }
    }
}
