using System.Collections;
using UnityEngine;
//TODO UPRATAT
public class PlatformProperties : MonoBehaviour
{
    [SerializeField] private bool isStickable = false;
    [SerializeField] private bool isBrakeable = false;
    [SerializeField] private bool isBroken = false;
    [SerializeField] private int chanceToBreak = 80;
    [SerializeField] private float timeToBreak = 1f;
    [SerializeField] private float timeToRespawn = 3f;

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
        if (collision.gameObject.CompareTag("Player") && isBrakeable && rnd < chanceToBreak)
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
        this.gameObject.SetActive(false);
        Debug.Log("Zlomena");

        if (timeToRespawn >= 0)
        {
            timeToRespawn -= Time.deltaTime;
            Debug.Log("Time: " + timeToRespawn);
        }

        if (timeToRespawn <= 0)
        {
            this.gameObject.SetActive(true);
            timeToBreak = 1f;
            timeToRespawn = 3f;
            isBroken = false;
            Debug.Log("Opravena");
        }
    }
}
