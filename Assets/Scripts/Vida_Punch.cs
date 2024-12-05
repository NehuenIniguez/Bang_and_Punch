using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida_Punch: MonoBehaviour
{
    public float vidaActualPunch;
    public float vidaMaximaPunch;
    private bool RecibeDanio = false;
    private Animator animator;
    void Start()
    {
        vidaActualPunch = vidaMaximaPunch;    
        animator = GetComponent<Animator>();        
    }

     public void Daño_Punch (float dañoPunch)
    {
        RecibeDanio = true;
        vidaActualPunch = vidaActualPunch - dañoPunch;
        
        if (vidaActualPunch <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOverCoop");
        }
        if (RecibeDanio )
        {
            RecibeDanio = false;
        }
    }
    
    public void CurarVida(float CurasionVida)
    {
        float vidaTemporal = vidaActualPunch + CurasionVida;
        if (vidaTemporal> vidaMaximaPunch)
        {
            vidaMaximaPunch = vidaTemporal;
        }
        else
        {
            vidaActualPunch = vidaTemporal;
        }
    }
    void Update()
    {
        animator.SetBool("RecibeDanio", RecibeDanio);
    }
}
