using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Modo_Settings : MonoBehaviour
{
    public void Mode_Settings()
    {
        SceneManager.LoadScene("SelectorModo");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
