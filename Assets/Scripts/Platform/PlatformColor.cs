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
        platformColor = gameObject.GetComponent<SpriteRenderer>().color;
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if ((PlayerProperties.playerColor == PlayerProperties.displayedColor)
            && PlayerProperties.playerColor == platformColor)
        {
            collider.enabled = true;
            return;
        }

        if (PlayerProperties.playerColor != platformColor)
        {
            collider.enabled = false;
            return;
        }

        if (PlayerProperties.playerColor != PlayerProperties.displayedColor)
        {
            collider.enabled = true;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCollision(collision.collider);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CheckCollision(collision.collider);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CheckCollision(collision.collider);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void CheckCollision(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player")
            && PlayerProperties.playerColor.Equals(platformColor))
        {
            this.collider.enabled = true;
        }
        else if (!this.collider.isTrigger)
        {
            this.collider.enabled = false;
        }
    }
}