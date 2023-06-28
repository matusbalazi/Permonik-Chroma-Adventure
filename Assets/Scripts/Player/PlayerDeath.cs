using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public AudioSource respawnSFX;
    public AudioSource deathSFX;
    private readonly int deathHeight = -100;
    private readonly Vector3 respawnPosition = new(0f, 10f, 0f);
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject newGameButton;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private Image menuButtonImage;
    [SerializeField] private Image newGameButtonImage;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject controller;
    private XMLHighscoreManager HighscoreManager;

    private void Start()
    {
        HighscoreManager = controller.GetComponent<XMLHighscoreManager>();
    }
    private void Update()
    {
        if (GameProperties.isPaused)
        {
            return;
        }

        if (!HitTaken())
        {
            return;
        }

        if (PlayerProperties.lives > 0)
        {
            if (!respawnSFX.isPlaying)
            {
                respawnSFX.Play();
            }

            PlayerProperties.lives--;
            transform.position = respawnPosition;
        }
        else
        {
            if (!deathSFX.isPlaying)
            {
                deathSFX.Play();
            }

            Time.timeScale = 0;
            deathScreen.SetActive(true);
            HighscoreManager.AddScore(PlayerProperties.score);
            scoreText.text = "Score: " + PlayerProperties.score.ToString();
            SetToPlayerColors();
            GameProperties.isPaused = true;
            GameProperties.isEnded = true;
            EventSystem.current.SetSelectedGameObject(newGameButton);
        }       
    }

    private bool HitTaken()
    {
        if (transform.position.y < deathHeight)
        {
            return true;
        }
        else if (WaterRise.WaterPos.y > transform.position.y - 80)
        {
            PlayerProperties.lives = 0;
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
}
