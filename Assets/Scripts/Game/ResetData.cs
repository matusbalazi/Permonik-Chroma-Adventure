using UnityEngine;

public class ResetData : MonoBehaviour
{
    public void Start()
    {
        GameProperties.isPaused = false;
        Time.timeScale = 1;
        PlayerProperties.lives = DefaultValues.lives;
        PlayerProperties.speedForce = DefaultValues.speedForce;
        PlayerProperties.jumpForce = DefaultValues.jumpForce;
        PlayerProperties.gems = DefaultValues.gems;
        GameProperties.isEnded = false;
    }
}
