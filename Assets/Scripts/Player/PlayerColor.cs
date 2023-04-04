using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    Color originalColor;
    float originalColorChangeCooldown;
    float originalColorChangeCountdown;

    void Start()
    {
        PlayerProperties.playerColor = this.gameObject.GetComponent<Renderer>().material.color;
        originalColor = PlayerProperties.playerColor;
        originalColorChangeCooldown = PlayerProperties.colorChangeCooldown;
        originalColorChangeCountdown = PlayerProperties.colorChangeCountdown;
    }

    void Update()
    {
        if (Input.GetButtonDown("AButtonGreen") && PlayerProperties.playerColor != Color.green)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0.4334f, 0.78f, 0.234f);
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        if (Input.GetButtonDown("BButtonRed") && PlayerProperties.playerColor != Color.red)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0.8117647f, 0.1803922f, 0.1764706f);
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        if (Input.GetButtonDown("XButtonBlue") && PlayerProperties.playerColor != Color.blue)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0.01176471f, 0.6509804f, 0.8901961f);
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        if (Input.GetButtonDown("YButtonYellow") && PlayerProperties.playerColor != Color.yellow)
        {
            this.gameObject.GetComponent<Renderer>().material.color = new Color(0.9019608f, 0.8f, 0.1215686f);
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        PlayerProperties.playerColor = this.gameObject.GetComponent<Renderer>().material.color;

        if (PlayerProperties.colorChangeCooldown >= 0)
        {
            PlayerProperties.colorChangeCooldown -= Time.deltaTime;
        }

        if (PlayerProperties.colorChangeCooldown <= 0 && PlayerProperties.colorChangeCountdown >= 0)
        {
            PlayerProperties.colorChangeCountdown -= Time.deltaTime;
            this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(PlayerProperties.playerColor, originalColor, Time.deltaTime / (originalColorChangeCountdown / 2));
        }

        if (PlayerProperties.colorChangeCountdown <= 0)
        {
            PlayerProperties.playerColor = originalColor;
        }
    }
}
