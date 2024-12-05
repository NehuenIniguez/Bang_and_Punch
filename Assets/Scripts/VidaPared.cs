using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPared : MonoBehaviour
{
    [SerializeField] private float vidaPared;
    private AudioSource audioSource;
    [SerializeField] private AudioClip seCae;
    private new Collider2D collider2D;
    private new Renderer renderer;
    private void Awake() {
        collider2D = GetComponent<Collider2D>();
        renderer = GetComponent<Renderer>();
    }
    private void Start() {
        audioSource=GetComponent<AudioSource>();
    }
    public void TomarDaño (float Daño)
    {
        vidaPared -= Daño;
        if (vidaPared<=0)
        {
            //audioSource.PlayOneShot(seCae);
            Destruir();
        }
    }

    private void Destruir()
    {
        collider2D.enabled = false;
        renderer.enabled = false;
    }
}
