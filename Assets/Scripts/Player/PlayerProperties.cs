using Unity.VisualScripting;
using UnityEngine;

public static class PlayerProperties
{
    public static float speedForce = 80f;
    public static float jumpForce = 100f;
    public static float gravityForce = 100f;
    public static Color playerColor;
    public static bool isStickActive = false;
    public static float remainingStickTime = 80f;
    public static float timeUntilStickRegen = 2f;
    public static float remainingColorTime = 10f;
    public static float timeUntilColorReset = 10f;
    public static int playerLifes = 3;
    public static int playerGems = 0;
    public static float colorChangeCooldown = 10f;
    public static float colorChangeCountdown = 10f;
    public static int distance = 0;

    public static Vector3 Checkpoint { get; set; }
}
