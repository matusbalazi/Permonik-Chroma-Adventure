using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
    public AudioSource rockSFX;
    private GameObject player;
    private GameObject rockRenderer;
    private GameObject spriteRenderer;
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
        player = GameObject.Find("Player");
        rockRenderer = GameObject.Find("RockRenderer");
        spriteRenderer = GameObject.Find("SpriteRenderer");
        mainCamera = GameObject.Find("MainCamera");
        defaultRockPosition = this.gameObject.transform.position;
        rockPositionX = this.gameObject.transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        distanceThreshold = Random.Range(100f, 150f);
        originalColor = rockRenderer.GetComponent<MeshRenderer>().material.color;
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
            fallForce = Random.Range(50f, 100f);
            rb.AddForce(Vector2.left * fallForce, ForceMode2D.Impulse);
            newColor = Colors.GetDifferentRandomColor(previousColor);

            rockRenderer.GetComponent<MeshRenderer>().material.color = newColor;
            spriteRenderer.GetComponent<SpriteRenderer>().material.color = newColor;
            previousColor = rockRenderer.GetComponent<MeshRenderer>().material.color;
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
            rockRenderer.GetComponent<MeshRenderer>().material.color = originalColor;
            spriteRenderer.GetComponent<SpriteRenderer>().material.color = originalColor;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerProperties.playerColor == rockRenderer.GetComponent<MeshRenderer>().material.color)
            {
                wasCorrectColor = true;
               
                this.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                rockRenderer.GetComponent<MeshRenderer>().enabled = false;
                spriteRenderer.GetComponent<SpriteRenderer>().enabled = false;
                rockSFX.Stop();
            }
            else
            {
                mainCamera.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
                mainCamera.GetComponent<Animator>().enabled = true;

                if (PlayerProperties.lives > 0)
                {
                    PlayerProperties.lives--;
                    player.transform.position = new(0f, 10f, 0f);
                }
                else
                {
                    GameProperties.isEnded = true;
                }
               
                wasReset = true;
                rockFell = false;
                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                this.gameObject.transform.position = defaultRockPosition; 
                rb.velocity = Vector3.zero;
                rockSFX.Stop();
            }       
        }
    }
}
