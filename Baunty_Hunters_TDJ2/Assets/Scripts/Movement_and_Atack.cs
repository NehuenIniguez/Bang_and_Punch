using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_and_Atack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.transform.Translate(4f* Time.deltaTime,0,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.transform.Translate(-4f* Time.deltaTime,0,0);
        }
        
        
    }
}
