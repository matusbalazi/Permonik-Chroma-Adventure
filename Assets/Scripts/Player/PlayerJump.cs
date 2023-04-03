using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce;
    private float gravityForce;
    private float distanceToGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = PlayerProperties.jumpForce;
        gravityForce = PlayerProperties.gravityForce;
        distanceToGround = GetComponent<CapsuleCollider2D>().bounds.extents.y;
    }

    void Update()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            PlayerProperties.speedForce = 50f;

            if (Input.GetAxis("RTJump") > 0 && IsGrounded())
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                PlayerProperties.speedForce = 40f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb.velocity.y) > 0.001f && !PlayerProperties.isStickActive)
        {
            rb.velocity += gravityForce * Time.deltaTime * Vector2.down;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, distanceToGround + 0.1f);
    }
}
