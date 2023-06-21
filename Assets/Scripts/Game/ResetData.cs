using UnityEngine;

public class ResetData : MonoBehaviour
{
    public void Start()
    {
        GameProperties.isPaused = false;
        Time.timeScale = 1;
        PlayerProperties.lives = 3;
        GameProperties.isEnded = false;
    }
}
