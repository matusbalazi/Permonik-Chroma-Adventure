using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseScreen;
    //TODO Pridat osetrenie na pauznutie len v hre + dorobit pause screen
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("StartButtonPause"))
        {
            if (pauseScreen.activeSelf)
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
                GameProperties.isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                GameProperties.isPaused = true;
            }
        }
    }
}
