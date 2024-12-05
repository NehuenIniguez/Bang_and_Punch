using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAlMenu : MonoBehaviour
{
    private Puntos puntajeManager;

    private void Start()
    {
        // Encontrar el PuntajeManager en la escena
        puntajeManager = GameObject.FindObjectOfType<Puntos>();
    }

    public void cambio()
    {
        SceneManager.LoadScene("MainMenu");   
    }

    public void Avanzar()
    {
        if (Puntos.instancia != null)
        {
            int puntajeTotal = Puntos.instancia.ObtenerPuntaje();

            if (puntajeTotal <= 3)
            {
                SceneManager.LoadScene("LevelTwo");
            }
            else if (puntajeTotal > 3)
            {
                SceneManager.LoadScene("ComingSon");
                Puntos.instancia.ReiniciarPuntaje();
            }
        }
       
    }

    public void Coop()
    {
        if (Puntos.instancia != null)
        {
            int puntajeTotal = Puntos.instancia.ObtenerPuntaje();

            if (puntajeTotal <= 3)
            {
                SceneManager.LoadScene("Cooperativo_Level1");
                Puntos.instancia.ReiniciarPuntaje();
            }
            else if (puntajeTotal > 3)
            {
                SceneManager.LoadScene("LevelTwo");
            }
        }
    }

    public void Versus()
    {
        SceneManager.LoadScene("Versus");
    }
}
