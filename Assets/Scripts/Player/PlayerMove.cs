using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public AudioSource footstepsSFX;
    private Rigidbody2D rb;
    private float speedForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedForce = PlayerProperties.speedForce;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector2 movement = new(moveHorizontal, 0f);
            transform.Translate(speedForce * Time.deltaTime * movement, Space.World);
            speedForce = PlayerProperties.speedForce;

            if (!footstepsSFX.isPlaying)
            {
                footstepsSFX.Play();
            }
        }
        else
        {
            footstepsSFX.Stop();
        }

        /*
         *  -----------------------------------------------------------------
         *  ALTERNATIVE MOVEMENT USING RIGIDBODY
         *  -----------------------------------------------------------------
         *  float moveHorizontal = Input.GetAxis("Horizontal");
         *  Vector2 movement = new Vector2(moveHorizontal, 0f);
         *  rb.velocity = speedForce * Time.deltaTIme * movement;  
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
