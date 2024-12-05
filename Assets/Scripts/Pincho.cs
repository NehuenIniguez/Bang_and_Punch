using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pincho : MonoBehaviour
{ 
    [SerializeField] private float velocidad;
    [SerializeField] private float dañoPunch; 
    public void DestruirPincho ()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);        
    }   

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(other.gameObject.name);
       if (other.gameObject.CompareTag("Pared"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.GetComponent<Vida_PJ>().Daño_PJ(dañoPunch);
           
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Piso"))
        {
            Destroy(this.gameObject);
        }
      
    }
   
}
