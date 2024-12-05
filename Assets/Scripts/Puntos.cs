using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntos : MonoBehaviour
{
    public static Puntos instancia; // Singleton

    private int puntos = 0;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // Mantiene el objeto entre escenas
        }
        else
        {
            Destroy(gameObject); // Destruye duplicados
        }
    }

    public void AgregarPuntos(int cantidad)
    {
        puntos += cantidad;
    }

    public int ObtenerPuntaje()
    {
        return puntos;
    }

    public void ReiniciarPuntaje()
    {
        puntos = 0;
    }
    
}
