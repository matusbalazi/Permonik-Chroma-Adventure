using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    private Color originalColor;
    private new Renderer renderer;

    void Start()
    {
        this.renderer = GetComponent<Renderer>();
        PlayerProperties.playerColor = this.gameObject.GetComponent<Renderer>().material.color;
        originalColor = PlayerProperties.playerColor;
    }

    //Cele tieto farby sa este pomenia
    void Update()
    {
        if (Input.GetButtonDown("AButtonGreen") && PlayerProperties.playerColor != Color.green)
        {
            ChangeColor(new Color(0.4334f, 0.78f, 0.234f));
        }

        if (Input.GetButtonDown("BButtonRed") && PlayerProperties.playerColor != Color.red)
        {
            ChangeColor(new Color(0.8117647f, 0.1803922f, 0.1764706f));
        }

        if (Input.GetButtonDown("XButtonBlue") && PlayerProperties.playerColor != Color.blue)
        {
            ChangeColor(new Color(0.01176471f, 0.6509804f, 0.8901961f));
        }

        if (Input.GetButtonDown("YButtonYellow") && PlayerProperties.playerColor != Color.yellow)
        {
            ChangeColor(new Color(0.9019608f, 0.8f, 0.1215686f));
        }


        if (PlayerProperties.remainingColorTime >= 0)
        {
            PlayerProperties.remainingColorTime -= Time.deltaTime;
        }

        if (PlayerProperties.remainingColorTime <= 0 && PlayerProperties.timeUntilColorReset >= 0)
        {
            PlayerProperties.timeUntilColorReset -= Time.deltaTime;
            renderer.material.color = Color.Lerp(PlayerProperties.playerColor, originalColor, Time.deltaTime / (Constants.timeUntilColorReset / 2));
        }
    }

    void ChangeColor(Color newColor)
    {
        renderer.material.color = newColor;
        PlayerProperties.playerColor = newColor;
        PlayerProperties.timeUntilColorReset = Constants.timeUntilColorReset;
        PlayerProperties.remainingColorTime = Constants.remainingColorTime;

    }
}
