using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controler : MonoBehaviour
{
    
   public Transform Player;
   public Transform playerTwo;
   public float detectionradius = 5.0f;
   public float speed = 2.0f;

   private Rigidbody2D rb;
   private Vector2 movement;
   private Vector2 movementTwo;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceTopPlayer = Vector2.Distance(transform.position, Player.position);
        float distanceTopPlayerTwo = Vector2.Distance(transform.position, playerTwo.position);
        if (distanceTopPlayer < detectionradius)
        {
            Vector2 direction = (Player.position - transform.position).normalized;

            movement = new Vector2 (direction.x, 0);
        }
        else
        {
            movement = Vector2.zero;
        }
       if(distanceTopPlayerTwo< detectionradius)
        {
            Vector2 directionTwo = (playerTwo.position - transform.position).normalized;

            movementTwo = new Vector2 (directionTwo.x,0);

        }
        else 
        {
            movementTwo = Vector2.zero;
        }
        
        rb.MovePosition(rb.position + movementTwo * speed * Time.deltaTime);
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
}
