using System.Collections;
using UnityEngine;
//TODO UPRATAT
public class PlatformProperties : MonoBehaviour
{
    [SerializeField] private bool isStickable = false;
    [SerializeField] private bool isBreakable = false;
    [SerializeField] private bool isBroken = false;
    [SerializeField] private int chanceToBreak = 80;
    [SerializeField] private float timeToBreak = 1f;
    [SerializeField] private float timeToRespawn = 3f;
    [SerializeField] private Sprite brokenPlatform;

    private int rnd;

    private void Start()
    {
        if (isBreakable)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            rnd = Random.Range(0, 100);

            if (rnd < chanceToBreak)
            {
                spriteRenderer.sprite = brokenPlatform;
                Color color = new (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.8f);
                spriteRenderer.color = color;
            }          
        }      
    }

    private void Update()
    {
        if (isBroken)
        {
            if (timeToBreak >= 0)
            {
                timeToBreak -= Time.deltaTime;
            }

            if (timeToBreak <= 0)
            {
                BreakPlatform();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isBreakable && rnd < chanceToBreak)
        {
            isBroken = true;
        }

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
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<Collider2D>().enabled = false;
        Debug.Log("Zlomena");

        if (timeToRespawn >= 0)
        {
            timeToRespawn -= Time.deltaTime;
            Debug.Log("Time: " + timeToRespawn);
        }

        if (timeToRespawn <= 0)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Collider2D>().enabled = true;
            timeToBreak = 1f;
            timeToRespawn = 3f;
            isBroken = false;
            Debug.Log("Opravena");
        }
    }
}
