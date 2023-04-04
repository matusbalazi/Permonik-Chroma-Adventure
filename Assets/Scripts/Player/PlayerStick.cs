using System;
using UnityEngine;

public class PlayerStick : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speedForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedForce = PlayerProperties.speedForce;
    }

    void Update()
    {
        if (Input.GetAxis("LTStick") > 0 && PlayerProperties.isStickActive)
        {
            if (PlayerProperties.remainingStickTime >= 0)
            {
                PlayerProperties.remainingStickTime -= Time.deltaTime;

                rb.gravityScale = 0f;
                float moveVertical = Input.GetAxis("Vertical");
                Vector2 movement = new(0f, moveVertical);
                transform.Translate(speedForce * Time.deltaTime * movement, Space.World);
            }
        }

        if (Input.GetAxis("LTStick") == 0 || PlayerProperties.remainingStickTime <= 0 || !PlayerProperties.isStickActive)
        {
            rb.gravityScale = 6f;
        }

        if (Input.GetAxis("LTStick") == 0 && Math.Round(Constants.remainingStickTime - PlayerProperties.remainingStickTime) > 1)
        {
            if (PlayerProperties.timeUntilStickRegen >= 0)
            {
                PlayerProperties.timeUntilStickRegen -= Time.deltaTime;
            }
        }

        if (PlayerProperties.timeUntilStickRegen <= 0)
        {
            PlayerProperties.remainingStickTime++;
            PlayerProperties.timeUntilStickRegen = Constants.timeUntilStickRegen;
        }
    }

}
