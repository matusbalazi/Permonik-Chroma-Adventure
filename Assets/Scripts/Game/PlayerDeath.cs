using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.position.y < -20)
        {
            if (PlayerProperties.playerLifes > 0)
            {
                PlayerProperties.playerLifes--;
                rb.position = new Vector2(-15f, 15f);
            } 
            else
            {
                GameProperties.isEnd = true;
            }         
        }
    }
}
