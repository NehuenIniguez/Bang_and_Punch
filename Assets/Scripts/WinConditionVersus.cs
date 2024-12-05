using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionVersus : MonoBehaviour
{
    public GameObject PlayerMalo;
    public GameObject playerTwo;
   
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("PlayerMalo"))
        {
            SceneManager.LoadScene("WinVersusMalo");  
        }
        if(other.gameObject.CompareTag("PlayerTwo"))
        {
            SceneManager.LoadScene("WinVersus");
        }
        
    }
}
