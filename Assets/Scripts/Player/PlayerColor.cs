using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    private Color originalColor;
    private new Renderer renderer;
    private readonly float colorDuration = 10f;
    private readonly float colorResetDuration = 10f;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        PlayerProperties.playerColor = renderer.material.color;
        originalColor = PlayerProperties.playerColor;
    }

    void Update()
    {
        if (GameProperties.isPaused)
        {
            return;
        }

        if (Input.GetButtonDown("AButtonGreen") && PlayerProperties.playerColor != Colors.green)
        {
            ChangeColor(Colors.green);
        }

        else if (Input.GetButtonDown("BButtonRed") && PlayerProperties.playerColor != Colors.red)
        {
            ChangeColor(Colors.red);
        }

        else if (Input.GetButtonDown("XButtonBlue") && PlayerProperties.playerColor != Colors.blue)
        {
            ChangeColor(Colors.blue);
        }

        else if (Input.GetButtonDown("YButtonYellow") && PlayerProperties.playerColor != Colors.yellow)
        {
            ChangeColor(Colors.yellow);
        }

        PlayerProperties.playerColor = renderer.material.color;

        if (PlayerProperties.remainingColorTime >= 0)
        {
            PlayerProperties.remainingColorTime -= Time.deltaTime;
        }

        if (PlayerProperties.remainingColorTime <= 0 && PlayerProperties.timeUntilColorReset >= 0)
        {
            PlayerProperties.timeUntilColorReset -= Time.deltaTime;
            renderer.material.color = Color
                .Lerp(PlayerProperties.playerColor, originalColor, Time.deltaTime / (colorResetDuration / 2));
        }

        if (PlayerProperties.colorChangeCountdown <= 0)
        {
            PlayerProperties.playerColor = originalColor;
        }
    }

    void ChangeColor(Color newColor)
    {
        renderer.material.color = newColor;
        PlayerProperties.timeUntilColorReset = colorResetDuration;
        PlayerProperties.remainingColorTime = colorDuration;
    }
}