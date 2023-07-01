using UnityEngine;

public class StringsCollision : MonoBehaviour
{
    private GameObject player;
    private GameObject mainCamera;
    public AudioSource respawnSFX;
    private float remainingForceTime = 0.4f;
    private bool wasCorrectColor = false;

    void Start()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("MainCamera");
    }

    void Update()
    {
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
                remainingForceTime = 0.4f;
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
            if (PlayerProperties.playerColor == this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color)
            {
                wasCorrectColor = true;

                this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
                this.gameObject.GetComponentInChildren<CircleCollider2D>().enabled = false;

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
                }
                else
                {
                    GameProperties.isEnded = true;
                }

                player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                this.gameObject.SetActive(false);
            }
        }
    }
}
