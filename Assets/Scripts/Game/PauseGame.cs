using UnityEngine;

public class PauseGame : MonoBehaviour
{
    //TODO Pridat osetrenie na pauznutie len v hre + dorobit pause screen
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("StartButtonPause"))
        {
            if (GameProperties.isPaused)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
            GameProperties.isPaused = !GameProperties.isPaused;
        }
    }
}
