using UnityEngine;
//TODO TENTO SUBOR TREBA?
public class PlayerWallStick : MonoBehaviour
{
    Rigidbody2D rb;
    private bool isWallSliding;
    private float wallSlidingSpeed;

    private bool isWallJumping;
    private float wallJumpDirection;
    private float wallJumpTime;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        WallSlide();
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && Input.GetAxis("Horizontal") != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }
}
