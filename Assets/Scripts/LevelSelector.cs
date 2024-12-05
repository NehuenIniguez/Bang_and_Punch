using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
   public void Coop()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Versus()
    {
        SceneManager.LoadScene("Tutorial_Versus");
    }
 
}
