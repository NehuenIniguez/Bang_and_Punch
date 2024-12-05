using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida_PJ : MonoBehaviour
{
    public float vidaActual;
    public float vidaMaxima;
    public AnimacionVida animacionVida;
    public DosDeVida dosDeVida;
    public UnoDeVida unoDeVida;

    // Referencia al otro objeto con Vida_PJ (Bang o Punch)
    public Vida_PJ otroObjetoVida;

    void Start()
    {
        vidaActual = vidaMaxima;

        // Asignar el otro objeto de vida al comenzar
        if (otroObjetoVida == null)
        {
            // Asume que los objetos se llaman "Bang" y "Punch" en la escena
            if (gameObject.name == "Bang")
            {
                otroObjetoVida = GameObject.Find("Punch").GetComponent<Vida_PJ>();
            }
            else if (gameObject.name == "Punch")
            {
                otroObjetoVida = GameObject.Find("Bang").GetComponent<Vida_PJ>();
            }
        }
    }

    public void Daño_PJ(float dañoEnemigo)
    {
        vidaActual -= dañoEnemigo;

        // Sincronizar el daño en el otro objeto
        if (otroObjetoVida != null && otroObjetoVida.vidaActual > 0)
        {
            otroObjetoVida.vidaActual -= dañoEnemigo;
            otroObjetoVida.ActualizarAnimacionesVida();
        }

        if (vidaActual <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverCoop");
        }
        else
        {
            ActualizarAnimacionesVida();
        }
    }

    public void CurarVida(float curacionVida)
    {
        float vidaTemporal = vidaActual + curacionVida;
        vidaActual = Mathf.Min(vidaTemporal, vidaMaxima);

        // Sincronizar la curación en el otro objeto
        if (otroObjetoVida != null && otroObjetoVida.vidaActual < otroObjetoVida.vidaMaxima)
        {
            otroObjetoVida.vidaActual = Mathf.Min(otroObjetoVida.vidaActual + curacionVida, otroObjetoVida.vidaMaxima);
            otroObjetoVida.ActualizarAnimacionesVida();
        }

        ActualizarAnimacionesVida();
    }

    private void ActualizarAnimacionesVida()
    {
        if (animacionVida != null) animacionVida.ActualizarVida(vidaActual);
        if (dosDeVida != null) dosDeVida.ActualizarVida(vidaActual);
        if (unoDeVida != null) unoDeVida.ActualizarVida(vidaActual);
    }
}
