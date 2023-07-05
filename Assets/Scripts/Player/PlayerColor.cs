using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerColor : MonoBehaviour
{
    public AudioSource maskSFX;
    private Color originalColor = Color.white;
    private new Renderer renderer;
    private Light2D light;
    private readonly float colorDuration = 10f;
    private readonly float colorResetDuration = 10f;

    void Start()
    {
        renderer = GameObject.Find("mask").GetComponent<MeshRenderer>();
        light = transform.Find("Light 2D").GetComponent<Light2D>();

        //renderer.material.color = Color.white;
    }

    void Update()
    {
        if (GameProperties.isPaused)
        {
            return;
        }

        if ((Input.GetButtonDown("AButtonGreen") || Input.GetKey(KeyCode.G)) /*&& PlayerProperties.playerColor != Colors.green*/)
        {
            ChangeColor(Colors.green);
        }

        else if ((Input.GetButtonDown("BButtonRed") || Input.GetKey(KeyCode.R)) /*&& PlayerProperties.playerColor != Colors.red*/)
        {
            ChangeColor(Colors.red);
        }

        else if ((Input.GetButtonDown("XButtonBlue") || Input.GetKey(KeyCode.B)) /*&& PlayerProperties.playerColor != Colors.blue*/)
        {
            ChangeColor(Colors.blue);
        }

        else if ((Input.GetButtonDown("YButtonYellow") || Input.GetKey(KeyCode.Y)) /*&& PlayerProperties.playerColor != Colors.yellow*/)
        {
            ChangeColor(Colors.yellow);
        }

        if (PlayerProperties.remainingColorTime >= 0)
        {
            PlayerProperties.remainingColorTime -= Time.deltaTime;
        }

        if (PlayerProperties.remainingColorTime <= 0 && PlayerProperties.timeUntilColorReset >= 0)
        {
            PlayerProperties.timeUntilColorReset -= Time.deltaTime;

            renderer.materials[0].color = Color.Lerp(
                PlayerProperties.displayedColor,
                originalColor,
                Time.deltaTime / (colorResetDuration / 2)
                );

            light.color = Color.Lerp(
               light.color,
               originalColor,
               Time.deltaTime / (colorResetDuration / 2)
               );


            PlayerProperties.displayedColor = renderer.materials[0].color;
        }

        if (PlayerProperties.timeUntilColorReset <= 0)
        {
            PlayerProperties.playerColor = originalColor;
            PlayerProperties.displayedColor = originalColor;
        }
    }

    void ChangeColor(Color newColor)
    {
        if (!maskSFX.isPlaying)
        {
            maskSFX.Play();
        }

        PlayerProperties.playerColor = newColor;

        renderer.materials[0].color = Color.Lerp(
            PlayerProperties.displayedColor,
            newColor,
            1f
        );

        light.color = Color.Lerp(
            newColor,
            Color.white,
            0.65f
        );
        //newMaterial;
        //.material.color = newColor;
        PlayerProperties.displayedColor = newColor;
        PlayerProperties.timeUntilColorReset = colorResetDuration;
        PlayerProperties.remainingColorTime = colorDuration;
    }
}