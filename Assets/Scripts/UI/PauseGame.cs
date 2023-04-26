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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("StartButtonPause"))
        {
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
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        GameProperties.isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
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
