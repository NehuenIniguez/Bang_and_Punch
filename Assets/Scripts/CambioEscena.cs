using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    private void Update() 
    {
        if(Input.GetButton("Fire1") || Input.GetButton("Jump"))
        {
            cambio();
        }
        
    }
    private void cambio()
    {
        SceneManager.LoadScene("Cooperativo_Level1");
    }
}
