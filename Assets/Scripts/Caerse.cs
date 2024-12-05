using System.Collections;
using UnityEngine;

public class Caerse : MonoBehaviour
{
    [SerializeField] private float Tcaida;  // Tiempo que el objeto está desactivado
    [SerializeField] private float delayBeforeDeactivate = 1f;  // Tiempo antes de desactivar
    private new Collider2D collider2D;
    private new Renderer renderer;

    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerTwo"))
        {
            StartCoroutine(DeactivateTemporarily());
        }
    }

    private IEnumerator DeactivateTemporarily()
    {
        yield return new WaitForSeconds(Tcaida); // Espera antes de desactivar

        // Desactiva el collider y el renderer (hace que el objeto sea "invisible" y "no interactuable")
        collider2D.enabled = false;
        renderer.enabled = false;

        // Espera el tiempo especificado antes de reactivar
        yield return new WaitForSeconds(delayBeforeDeactivate);

        // Reactiva el collider y el renderer
        collider2D.enabled = true;
        renderer.enabled = true;
    }
}
