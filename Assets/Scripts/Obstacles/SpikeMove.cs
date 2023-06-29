using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMove : MonoBehaviour
{
    public AudioSource spikeSFX;
    private GameObject player;
    private GameObject mainCamera;
    public bool isAboveGround;
    public bool isBelowGround;
    private float movementSpeed = 20f;   
    private float distanceThreshold = 70f;
    private float travelDistance = 10f;
    private float defaultPosition;   
    private bool wasColorChanged = false;
    private Color newColor;
    private float colorChangeTime;

    void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("MainCamera");
        defaultPosition = transform.localPosition.y;
        colorChangeTime = Random.Range(2, 6);
    }

    void Update()
    {
        float distance = player.transform.position.x - this.gameObject.transform.position.x;

        if (Mathf.Abs(distance) <= distanceThreshold)
        {
            if (isBelowGround && !isAboveGround)
            {
                if (this.gameObject.transform.localPosition.y <= (defaultPosition + travelDistance*2))
                {
                    transform.Translate(Vector2.up * Time.deltaTime * movementSpeed, Space.World);

                    if (!spikeSFX.isPlaying)
                    {
                        spikeSFX.Play();
                    }
                }
            }

            if (!isBelowGround && isAboveGround)
            {
                if (this.gameObject.transform.localPosition.y >= (defaultPosition - travelDistance/4))
                {
                    transform.Translate(Vector2.down * Time.deltaTime * movementSpeed, Space.World);

                    spikeSFX.Stop();
                }
            }

            if (Mathf.Round(this.gameObject.transform.localPosition.y) == Mathf.Round(defaultPosition + travelDistance*2))
            {
                isBelowGround = false;
                isAboveGround = true;
            }

            if (Mathf.Round(this.gameObject.transform.localPosition.y) == Mathf.Round(defaultPosition - travelDistance/4))
            {
                isBelowGround = true;
                isAboveGround = false;
            }

            if (!wasColorChanged)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Colors.GetRandomColor();
                wasColorChanged = true;
            }

            if (colorChangeTime >= 0)
            {
                colorChangeTime -= Time.deltaTime;
            }

            if (colorChangeTime <= 0)
            {
                newColor = Colors.GetRandomColor();

                while (newColor == this.gameObject.GetComponent<SpriteRenderer>().color)
                {
                    newColor = Colors.GetRandomColor();
                }

                this.gameObject.GetComponent<SpriteRenderer>().color = newColor;

                colorChangeTime = Random.Range(2, 6);
            }
        }
        else
        {
            spikeSFX.Stop();

            if (this.gameObject.transform.localPosition.y < defaultPosition)
            {
                transform.Translate(Vector2.up * Time.deltaTime * movementSpeed, Space.World);
            }

            if (this.gameObject.transform.localPosition.y > defaultPosition)
            {
                transform.Translate(Vector2.down * Time.deltaTime * movementSpeed, Space.World);
            }

            if (wasColorChanged)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                wasColorChanged = false;
            }
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
            if (this.gameObject.GetComponent<SpriteRenderer>().color != PlayerProperties.playerColor)
            {
                mainCamera.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
                mainCamera.GetComponent<Animator>().enabled = true;

                if (PlayerProperties.lives > 0)
                {
                    PlayerProperties.lives--;
                    Destroy(gameObject);
                    //player.transform.position = new(0f, 10f, 0f);
                }
                else
                {
                    GameProperties.isEnded = true;
                }
            }           
        }
    }
}
