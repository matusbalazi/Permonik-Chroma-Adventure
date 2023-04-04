using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Color playerColor;
    [SerializeField] Color platformColor;
    [SerializeField] Color currentPlayerColor;
    private new SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Colors.GetRandomColor();
        playerColor = player.GetComponent<SpriteRenderer>().color;
        platformColor = gameObject.GetComponent<SpriteRenderer>().color;
        currentPlayerColor = PlayerProperties.playerColor;
    }

    private void Update()
    {
        if (currentPlayerColor != PlayerProperties.playerColor)
        {
            currentPlayerColor = PlayerProperties.playerColor;

            if (PlayerProperties.playerColor.Equals(platformColor) && !PlayerProperties.playerColor.Equals(playerColor))
            {
                this.gameObject.GetComponent<Collider2D>().isTrigger = false;
            } 
            else
            {
                this.gameObject.GetComponent<Collider2D>().isTrigger = true;          
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && PlayerProperties.playerColor.Equals(platformColor) && !PlayerProperties.playerColor.Equals(playerColor))
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        else
        {
            this.gameObject.GetComponent<Collider2D>().isTrigger = true;
            //player.transform.SetParent(null); //TODO PRECO???
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && PlayerProperties.playerColor.Equals(platformColor) && !PlayerProperties.playerColor.Equals(playerColor))
            this.gameObject.GetComponent<Collider2D>().isTrigger = false;
        else
        {
            this.gameObject.GetComponent<Collider2D>().isTrigger = true;
            //player.transform.SetParent(null); //TODO PRECO???
        }
    }
}
