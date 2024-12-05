using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PasoVersus : MonoBehaviour
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
        SceneManager.LoadScene("Versus");
    }
}
