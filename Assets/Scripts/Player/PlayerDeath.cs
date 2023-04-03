using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private readonly int deathHeight = -20;
    private static readonly Vector2 respawnPosition = new(-15f, 15f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.position.y < deathHeight)
        {
            if (PlayerProperties.playerLifes > 0)
            {
                PlayerProperties.playerLifes--;
                rb.position = respawnPosition;
            }
            else
            {
                GameProperties.isEnd = true;
            }
        }
    }
}
