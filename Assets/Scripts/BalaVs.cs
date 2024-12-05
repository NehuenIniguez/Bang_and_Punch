using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BalaVS : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;

    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }   
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
   

    
}
