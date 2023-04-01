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
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        if (Input.GetButtonDown("BButtonRed") && PlayerProperties.playerColor != Color.red)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        if (Input.GetButtonDown("XButtonBlue") && PlayerProperties.playerColor != Color.blue)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            PlayerProperties.colorChangeCooldown = originalColorChangeCooldown;
            PlayerProperties.colorChangeCountdown = originalColorChangeCountdown;
        }

        if (Input.GetButtonDown("YButtonYellow") && PlayerProperties.playerColor != Color.yellow)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
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
    }
}
