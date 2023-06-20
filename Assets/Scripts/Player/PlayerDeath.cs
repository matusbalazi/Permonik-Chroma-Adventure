using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
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

        if (transform.position.y >= deathHeight)
        {
            return;
        }

        //else if (WaterRise.WaterPos.y > transform.position.y - 80)
        //{
        //    GameProperties.isEnd = true;
        //}

        if (PlayerProperties.playerLifes > 0)
        {
            PlayerProperties.playerLifes--;
            transform.position = respawnPosition;
        }
        else
        {
            Time.timeScale = 0;
            deathScreen.SetActive(true);
            HighscoreManager.AddScore(PlayerProperties.score);
            scoreText.text = "Score: " + PlayerProperties.score.ToString();
            SetToPlayerColors();
            GameProperties.isPaused = true;
            EventSystem.current.SetSelectedGameObject(newGameButton);
        }
    }
    private void SetToPlayerColors()
    {
        Color color = PlayerProperties.playerColor;
        menuButtonImage.color = color;
        newGameButtonImage.color = color;
        gameOverText.color = color;
    }
}
