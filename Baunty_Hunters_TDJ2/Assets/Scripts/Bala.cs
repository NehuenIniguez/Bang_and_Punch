using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;

    private void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }   
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Enemigo"))
        {
            other.gameObject.transform.GetComponent<Enemigo>().TomarDaño(daño);
        }
        Destroy(this.gameObject);

    }
}
