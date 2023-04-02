using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour 
{
    Rigidbody2D rb;
    float jumpForce;
    float gravityForce;
    float distanceToGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = PlayerProperties.jumpForce;
        gravityForce = PlayerProperties.gravityForce;
        distanceToGround = GetComponent<CapsuleCollider2D>().bounds.extents.y;
    }

    void Update()
    {
        
        if (!GameProperties.isPaused)
        {
            if (Input.GetAxis("RTJump") > 0 && Mathf.Abs(rb.velocity.y) < 0.001f && IsGrounded())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                PlayerProperties.speedForce = 40f;
            }          

            if (Mathf.Abs(rb.velocity.y) < 0.001f)
            {
                PlayerProperties.speedForce = 50f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.y) > 0.001f && !PlayerProperties.isStickActive)
        {
            rb.velocity += Vector2.down * gravityForce * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + 0.1f);
    }
}
