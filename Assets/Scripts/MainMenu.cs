using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip Confirmar;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    public void Modo()
    {
        audioSource.PlayOneShot(Confirmar);
        SceneManager.LoadScene("SelectorModo");
        
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
 
}
