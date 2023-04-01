using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour 
{
    Rigidbody2D rb;
    float distanceToGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distanceToGround = GetComponent<CapsuleCollider2D>().bounds.extents.y;
    }

    void Update()
    {
        
        if (!GameProperties.isPaused)
        {
            if (Input.GetAxis("RTJump") > 0 && Mathf.Abs(rb.velocity.y) < 0.001f && IsGrounded())
            {
                rb.AddForce(Vector2.up * PlayerProperties.jumpForce, ForceMode2D.Impulse);
                PlayerProperties.speedForce = 4f;
            }          

            if (Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                PlayerProperties.speedForce = 5f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.y) > 0.001f && !PlayerProperties.isStickActive)
        {
            rb.velocity += Vector2.down * PlayerProperties.gravityForce * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + 0.1f);
    }
}
