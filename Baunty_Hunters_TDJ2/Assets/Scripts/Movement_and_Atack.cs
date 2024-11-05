using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_and_Atack : MonoBehaviour
{
    private Animator animator;
     private AudioSource audioSource;
    [SerializeField] private AudioClip seMueve;
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("SeMueve", true);
            gameObject.transform.Translate(4f* Time.deltaTime,0,0);
            //audioSource.PlayOneShot(seMueve);
        }
        if (Input.GetKey(KeyCode.A))
        {  
            gameObject.transform.Translate(4f* Time.deltaTime,0,0);
            animator.SetBool("SeMueve", true);
            //audioSource.PlayOneShot(seMueve);
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("SeMueve", false);
        }
         if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("SeMueve", false);
        } 
    }
    public void Sound()
    {
        audioSource.PlayOneShot(seMueve);
    }
}
