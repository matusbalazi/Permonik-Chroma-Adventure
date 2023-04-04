using UnityEngine;
//TODO UPRATAT
public class PlatformProperties : MonoBehaviour
{
    [SerializeField] private bool isStickable = false;
    [SerializeField] private bool isBrakeable = false;

    [SerializeField] private int chanceToBreak = 40;
    [SerializeField] private float timeToBreak = .7f;

    private int rnd;

    private void Start()
    {
        if (isBrakeable)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            rnd = Random.Range(0, 100);

            if (rnd < chanceToBreak)
            {
                Color color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.3f);
                spriteRenderer.color = color;
            }
            /*
             * Dobuducna na nastavenie ineho spritu pre oneTouch plosinu

            if (rnd < oneTouchChance)
                spriteRenderer.sprite = 
            */

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBrakeable && rnd < chanceToBreak)
            Invoke(nameof(BreakPlatform), timeToBreak);

        if (collision.gameObject.CompareTag("Player") && this.isStickable)
        {
            PlayerProperties.isStickActive = true;
            Debug.Log("Stick activated");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && this.isStickable)
        {
            PlayerProperties.isStickActive = false;
            Debug.Log("Stick deactivated");
        }
    }
    private void BreakPlatform()
    {
        gameObject.SetActive(false);
    }
}
