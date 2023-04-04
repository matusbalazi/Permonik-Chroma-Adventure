using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Color platformColor;
    private new SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Colors.GetRandomColor();
        platformColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerProperties.playerColor.Equals(platformColor))
            collision.gameObject.GetComponent<Collider2D>().isTrigger = false;
        else
        {
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
            //player.transform.SetParent(null); //TODO PRECO???
        }
    }
}
