using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerStick : MonoBehaviour
{
    Rigidbody2D rb;
    float originalStickLength;
    float originalStickCooldown;
    float speedForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedForce = PlayerProperties.speedForce;
        originalStickLength = PlayerProperties.stickLength;
        originalStickCooldown = PlayerProperties.stickCooldown;
    }

    void Update()
    {
        if (Input.GetAxis("LTStick") > 0 && PlayerProperties.isStickActive)
        {
            if (PlayerProperties.stickLength >= 0)
            {
                PlayerProperties.stickLength -= Time.deltaTime;
            
                if (!GameProperties.isPaused)
                {
                    rb.gravityScale = 0f;
                    float moveVertical = Input.GetAxis("Vertical");
                    Vector2 movement = new Vector2(0f, moveVertical);
                    transform.Translate(movement * Time.deltaTime * speedForce, Space.World);
                }
            }       
        }

        if (Input.GetAxis("LTStick") == 0 || PlayerProperties.stickLength <= 0 || !PlayerProperties.isStickActive)
        {
            rb.gravityScale = 1.0f;
        }

        if (Input.GetAxis("LTStick") == 0 && Math.Round(originalStickLength - PlayerProperties.stickLength) > 1)
        {
            if (PlayerProperties.stickCooldown >= 0)
            {
                PlayerProperties.stickCooldown -= Time.deltaTime;             
            }
        }

        if (PlayerProperties.stickCooldown <= 0)
        {
            PlayerProperties.stickLength++;
            PlayerProperties.stickCooldown = originalStickCooldown;
        }
    }

}
