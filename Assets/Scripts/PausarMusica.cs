using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PausarMusica : MonoBehaviour
{
    private AudioSource myMusicSource;
    private bool musicPaused = true;
    public static PausarMusica Instance {get; private set; }
void Start()
{
    GameObject musicObject = GameObject.FindWithTag("Music");
    if (musicObject != null)
    {
        myMusicSource = musicObject.GetComponent<AudioSource>();
    }
}

public void ToggleMusics()
{
    if (myMusicSource != null)
    {
        if (musicPaused)
        {
            myMusicSource.Play();  // Reanudar música
        }
        else
        {
            myMusicSource.Pause();  // Pausar música
        }
        musicPaused = !musicPaused;
    }
}

}
