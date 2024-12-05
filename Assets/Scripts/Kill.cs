using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other) 
   {
    if (other.gameObject.CompareTag("PlayeTwo"))
    {
        SceneManager.LoadScene("GameOverCoop");
    }
   }
}
