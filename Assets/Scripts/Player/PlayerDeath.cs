using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayerDeath : MonoBehaviour
{
    public AudioSource respawnSFX;
    public AudioSource deathSFX;
    private GameObject model;
    private readonly int deathHeight = -100;
    //private Vector3 respawnPosition =     
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject newGameButton;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private Image menuButtonImage;
    [SerializeField] private Image newGameButtonImage;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject controller;
    private XMLHighscoreManager HighscoreManager;
    private bool respawned = false;

    private void Start()
    {
        model = GameObject.Find("Model");
        PlayerProperties.Checkpoint = new(0, 15, 0);
        HighscoreManager = controller.GetComponent<XMLHighscoreManager>();
    }
    private void Update()
    {
        if (GameProperties.isPaused)
        {
            return;
        }

        if (GameProperties.isEnded)
        {
            EndGame();
        }

        if (!HitTaken(null))
        {
            return;
        }

        if (PlayerProperties.lives > 0)
        {
            respawnSFX.Play();

            PlayerProperties.lives--;
            transform.position = PlayerProperties.Checkpoint;
            WaterRise.WaterPos.Set(transform.position.x, WaterRise.WaterPos.y - 300, WaterRise.WaterPos.z);
            respawned = false;
        }
        else
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        deathSFX.Play();
        Time.timeScale = 0;
        deathScreen.SetActive(true);
        HighscoreManager.AddScore(PlayerProperties.score);
        scoreText.text = "Score: " + PlayerProperties.score.ToString();
        SetToPlayerColors();
        GameProperties.isPaused = true;
        GameProperties.isEnded = true;
        EventSystem.current.SetSelectedGameObject(newGameButton);
    }

    private bool HitTaken(Collider2D collision)
    {

        if (transform.position.y < deathHeight)
        {
            return true;
        }
        else if (collision != null)
        {
            return true;
        }
        else if (WaterRise.WaterPos.y > transform.position.y - 80)
        {
            return true;
        }
        return false;
    }

    private void SetToPlayerColors()
    {
        Color color = PlayerProperties.playerColor;
        menuButtonImage.color = color;
        newGameButtonImage.color = color;
        gameOverText.color = color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn") && respawned == false)
        {
            respawned = true;
        }

        if (collision.CompareTag("Fall"))
        {
            model.GetComponent<Animator>().Play("Falling Idle");
        }
    }
}
