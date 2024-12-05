using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Condition : MonoBehaviour
{
    
    private bool PlayerTouch = false;
    private bool PlayerTwoTouch = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerTouch = true;    
        }
        if (other.gameObject.CompareTag("PlayerTwo"))
        {
            PlayerTwoTouch = true;    
        }
        if (PlayerTouch && PlayerTwoTouch)
        {
            SceneManager.LoadScene("WinCoop");
        }
    }
}
