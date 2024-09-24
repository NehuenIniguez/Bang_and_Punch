using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void jugar_1()
    {
        SceneManager.LoadScene("Cooperativo_Level1");
    }
    public void jugar_2()
    {
        SceneManager.LoadScene("Versus");
    }
 
}
