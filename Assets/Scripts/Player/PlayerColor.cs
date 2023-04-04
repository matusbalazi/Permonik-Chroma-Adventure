using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    private Color originalColor;
    private new Renderer renderer;

    void Start()
    {
        this.renderer = GetComponent<Renderer>();
        PlayerProperties.playerColor = renderer.material.color;
        originalColor = PlayerProperties.playerColor;
    }

    //Cele tieto farby sa este pomenia
    void Update()
    {
        if (Input.GetButtonDown("AButtonGreen") && PlayerProperties.playerColor != Colors.green)
        {
            ChangeColor(Colors.green);
        }

        if (Input.GetButtonDown("BButtonRed") && PlayerProperties.playerColor != Colors.red)
        {
            ChangeColor(Colors.red);
        }

        if (Input.GetButtonDown("XButtonBlue") && PlayerProperties.playerColor != Colors.blue)
        {
            ChangeColor(Colors.blue);
        }

        if (Input.GetButtonDown("YButtonYellow") && PlayerProperties.playerColor != Colors.yellow)
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
                .Lerp(PlayerProperties.playerColor, originalColor, Time.deltaTime / (Constants.timeUntilColorReset / 2));
        }

        if (PlayerProperties.colorChangeCountdown <= 0)
        {
            PlayerProperties.playerColor = originalColor;
        }
    }

    void ChangeColor(Color newColor)
    {
        renderer.material.color = newColor;
        PlayerProperties.timeUntilColorReset = Constants.timeUntilColorReset;
        PlayerProperties.remainingColorTime = Constants.remainingColorTime;
    }
}