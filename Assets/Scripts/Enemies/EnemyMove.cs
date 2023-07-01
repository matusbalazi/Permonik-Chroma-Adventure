using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public bool isInDefaultPosition = true;
    public AudioSource spiderSFX;
    public AudioSource respawnSFX;
    private GameObject player;
    private GameObject spiderModel;
    private GameObject mainCamera;
    private float distanceThreshold = 110f;
    private float travelDistance = 70f;
    private float movementSpeed = 40f;
    private Rigidbody2D rb;
    private float defaultPosition;

    void Start()
    {
        player = GameObject.Find("Player");
        spiderModel = transform.Find("SpiderModel").gameObject;
        mainCamera = GameObject.Find("MainCamera");
        defaultPosition = this.gameObject.transform.localPosition.x;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distance = player.GetComponent<Rigidbody2D>().position.x - rb.position.x;

        if (Mathf.Abs(distance) >= distanceThreshold)
        {
            spiderModel.GetComponent<Animator>().Play("SpiderWalk");

            spiderSFX.Stop();

            if (Mathf.Round(this.gameObject.transform.eulerAngles.y) == 0 && this.gameObject.transform.localPosition.x >= (defaultPosition - travelDistance))
            {
                transform.Translate(Vector2.left * Time.deltaTime * movementSpeed, Space.World);
            }

            if (Mathf.Round(this.gameObject.transform.eulerAngles.y) == 180 && this.gameObject.transform.localPosition.x <= (defaultPosition + travelDistance))
            {
                transform.Translate(Vector2.right * Time.deltaTime * movementSpeed, Space.World);
            }

            if (this.gameObject.transform.localPosition.x <= (defaultPosition - travelDistance))
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            if (this.gameObject.transform.localPosition.x >= (defaultPosition + travelDistance))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else
        {
            spiderModel.GetComponent<Animator>().Play("SpiderIdle");

            if (!spiderSFX.isPlaying)
            {
                spiderSFX.Play();
            }

            if (Mathf.Round(this.gameObject.transform.eulerAngles.y) == 0 && player.GetComponent<Rigidbody2D>().position.x >= rb.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isInDefaultPosition = false;
            }

            if (Mathf.Round(this.gameObject.transform.eulerAngles.y) == 180 && player.GetComponent<Rigidbody2D>().position.x <= rb.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isInDefaultPosition = true;
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
            mainCamera.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
            mainCamera.GetComponent<Animator>().enabled = true;

            if (PlayerProperties.lives > 0)
            {
                PlayerProperties.lives--;
                if (!respawnSFX.isPlaying)
                {
                    respawnSFX.Play();
                }
                //player.transform.position = new(0f, 10f, 0f);
            }
            else
            {
                GameProperties.isEnded = true;
            }
        }
    }
}
