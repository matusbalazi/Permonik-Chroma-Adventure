using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Color platformColor;
    private new SpriteRenderer renderer;
    private new Collider2D collider;

    private void Start()
    {
        Color color = Colors.GetRandomColor();
        renderer.color = color;
        platformColor = gameObject.GetComponent<SpriteRenderer>().color;
        collider = gameObject.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (PlayerProperties.playerColor.Equals(platformColor))
            collider.isTrigger = false;
        else
        {
            collider.isTrigger = true;
            //player.transform.SetParent(null); TODO PRECO???
        }
    }
}
