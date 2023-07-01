using System.Collections;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    public AudioSource rockSFX;
    public AudioSource respawnSFX;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private GameObject mainCamera;
    private Rigidbody2D rb;
    private float fallForce = 50f;
    private float remainingForceTime = 0.7f;
    private float rockPositionX;
    private Vector3 defaultRockPosition;
    private float distanceThreshold;
    private bool wasCorrectColor = false;
    private bool wasReset = false;
    private bool rockFell = false;
    private Color originalColor;
    private Color previousColor;
    private Color newColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        mainCamera = player.transform.Find("MainCamera").gameObject;

        defaultRockPosition = this.gameObject.transform.position;
        rockPositionX = this.gameObject.transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        distanceThreshold = Random.Range(130f, 150f);
        originalColor = spriteRenderer.color;
        previousColor = Color.white;
    }

    void Update()
    {
        float distance = player.transform.position.x - this.gameObject.transform.position.x;

        if (Mathf.Abs(distance) <= distanceThreshold && rockPositionX >= player.transform.position.x && !rockFell)
        {
            if (!rockSFX.isPlaying)
            {
                rockSFX.Play();
            }

            rockFell = true;
            fallForce = Random.Range(200f, 250f);
            Quaternion rotation = Quaternion.Euler(0, 0, 45);
            rb.AddForce(rotation * Vector2.left * fallForce, ForceMode2D.Impulse);
            newColor = Colors.GetDifferentRandomColor(previousColor);

            spriteRenderer.color = newColor;
            previousColor = spriteRenderer.color;
        }

        if (wasCorrectColor)
        {
            if (remainingForceTime >= 0)
            {
                remainingForceTime -= Time.deltaTime;
            }

            if (remainingForceTime <= 0)
            {
                wasCorrectColor = false;
                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                remainingForceTime = 0.7f;
            }
        }

        if (wasReset)
        {
            spriteRenderer.color = originalColor;

            wasReset = false;
        }

        if (mainCamera.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !mainCamera.GetComponent<Animator>().IsInTransition(0))
        {
            Animator animation = mainCamera.GetComponent<Animator>().GetComponentInChildren<Animator>();
            animation.Rebind();
            animation.Update(0f);
            mainCamera.GetComponent<Animator>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameProperties.isPaused)
        {
            rockSFX.Stop();
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerProperties.playerColor == spriteRenderer.color)
            {
                wasCorrectColor = true;

                this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                rockSFX.Stop();
                spriteRenderer.enabled = false;

                // PlayerProperties.gems++;
            }
            else
            {
                mainCamera.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
                mainCamera.GetComponent<Animator>().enabled = true;

                if (PlayerProperties.lives > 0)
                {
                    PlayerProperties.lives--;

                    if (!respawnSFX.isPlaying)
                    {
                        respawnSFX.Play();
                    }

                    StartCoroutine(DestroyRock());
                }
                else
                {
                    GameProperties.isEnded = true;
                }

                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
    }

    IEnumerator DestroyRock()
    {
        while (respawnSFX.isPlaying)
        {
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(gameObject);
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
