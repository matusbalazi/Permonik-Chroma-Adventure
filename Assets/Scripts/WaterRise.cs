using UnityEngine;

public class WaterRise : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float defaultSpeed, diff;
    public static Vector3 WaterPos { get; set; }

    void Start()
    {
        WaterPos = transform.position;
    }

    void Update()
    {
        if (GameProperties.isPaused || GameProperties.isEnded)
        {
            return;
        }

        float waterX = player.transform.position.x;
        float waterY = transform.position.y;
        float diff = player.transform.position.y - waterY;
        float speed;

        if (diff < 200)
            speed = defaultSpeed / 300;
        else if (diff < 400)
            speed = defaultSpeed / 125;
        else if (diff < 600)
            speed = defaultSpeed / 25;
        else if (diff < 800)
            speed = defaultSpeed / 5;
        else
            speed = defaultSpeed;

        transform.position = new Vector2(waterX, waterY += speed);
        WaterPos = transform.position;
    }
}
