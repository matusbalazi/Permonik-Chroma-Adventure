using UnityEngine;

public static class PlayerProperties
{
    public static float speedForce = 80f;
    public static float jumpForce = 150f;
    public static float gravityForce = 300f;
    public static Color playerColor = Color.white;
    public static Color displayedColor = Color.white;
    public static bool isStickActive = false;
    public static float remainingStickTime = 80f;
    public static float timeUntilStickRegen = 2f;
    public static float remainingColorTime = 10f;
    public static float timeUntilColorReset = 10f;
    public static int lives = 3;
    public static int gems = 0;
    public static float colorChangeCooldown = 10f;
    public static int score = 0;
    public static int distance = 0;

    public static Vector3 Checkpoint { get; set; }
}
