using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private Image resumeButtonImage;
    [SerializeField] private Image menuButtonImage;
    [SerializeField] private TMP_Text pausedText;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip buttonSelect;


    private XMLHighscoreManager HighscoreManager;

    private void Start()
    {
        HighscoreManager = GetComponent<XMLHighscoreManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("StartButtonPause"))
        {
            if (GameProperties.isEnded)
            {
                return;
            }

            if (pauseScreen.activeSelf)
            {
                Unpause();
            }
            else
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                SetToPlayerColors();
                GameProperties.isPaused = true;
                EventSystem.current.SetSelectedGameObject(resumeButton);
            }
        }
    }

    public void Unpause()
    {
        pauseScreen.SetActive(false);
        GameProperties.isPaused = false;
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        HighscoreManager.SaveScores();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ReturnToMainMenuWithoutSaving()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void NewGame()
    {
        HighscoreManager.SaveScores();
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    private void SetToPlayerColors()
    {
        Color color = PlayerProperties.playerColor;
        resumeButtonImage.color = color;
        menuButtonImage.color = color;
        pausedText.color = color;
    }

    public void ButtonSelectSound()
    {
        audioSource.PlayOneShot(buttonSelect);
    }
}
