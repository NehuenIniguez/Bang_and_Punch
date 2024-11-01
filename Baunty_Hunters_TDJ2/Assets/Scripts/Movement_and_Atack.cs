using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_and_Atack : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(4f* Time.deltaTime,0,0);
            animator.SetBool("SeMueve", true);
        }
        if (Input.GetKey(KeyCode.A))
        {  
            gameObject.transform.Translate(4f* Time.deltaTime,0,0);
            animator.SetBool("SeMueve", true);
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
}
