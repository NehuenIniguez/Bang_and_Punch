using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Modo()
    {
        SceneManager.LoadScene("SelectorModo");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
 
}
