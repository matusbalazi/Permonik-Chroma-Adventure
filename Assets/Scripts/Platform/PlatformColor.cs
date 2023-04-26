using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Color playerColor;
    [SerializeField] private Color platformColor;
    [SerializeField] private Color currentPlayerColor;
    private new SpriteRenderer renderer;
    private new Collider2D collider;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Colors.GetRandomColor();
        playerColor = player.GetComponent<SpriteRenderer>().color;
        platformColor = gameObject.GetComponent<SpriteRenderer>().color;
        currentPlayerColor = PlayerProperties.playerColor;
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (currentPlayerColor != PlayerProperties.playerColor)
        {
            currentPlayerColor = PlayerProperties.playerColor;

            if (PlayerProperties.playerColor.Equals(platformColor) && !PlayerProperties.playerColor.Equals(playerColor))
            {
                collider.isTrigger = false;
            }
            else
            {
                collider.isTrigger = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCollision(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void CheckCollision(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")
            && PlayerProperties.playerColor.Equals(platformColor)
            && !PlayerProperties.playerColor.Equals(playerColor))
        {
            this.collider.isTrigger = false;
        }
        else if (!this.collider.isTrigger)
        {
            this.collider.isTrigger = true;
        }
    }
}