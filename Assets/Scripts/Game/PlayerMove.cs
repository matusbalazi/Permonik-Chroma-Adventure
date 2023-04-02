using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    float speedForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        speedForce = PlayerProperties.speedForce;
    }

    void Update()
    {
        if (!GameProperties.isPaused)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(moveHorizontal, 0f);
            transform.Translate(movement * speedForce * Time.deltaTime, Space.World);
        }
        
        speedForce = PlayerProperties.speedForce;
        /*
         *  -----------------------------------------------------------------
         *  ALTERNATIVE MOVEMENT USING RIGIDBODY
         *  -----------------------------------------------------------------
         *  float moveHorizontal = Input.GetAxis("Horizontal");
         *  Vector2 movement = new Vector2(moveHorizontal, 0f);
         *  rb.velocity = movement * speedForce;  
        */

        /*
         *  -----------------------------------------------------------------
         *  ALTERNATIVE CONTROL USING KEYBOARD
         *  -----------------------------------------------------------------
         *  if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
         *  {
         *      transform.Translate(Vector2.left * Time.deltaTime * forwardSpeed, Space.World);
         *  }
         *  
         *  if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
         *  {
         *      transform.Translate(Vector2.right * Time.deltaTime * forwardSpeed, Space.World);
         *  }
        */
    }
}
