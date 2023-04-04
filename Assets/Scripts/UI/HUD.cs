using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Text distanceValue;
    public Text livesValue;
    public Text gemsValue;
    void Update()
    {
        PlayerProperties.distance = (int)((player.transform.position.x + player.transform.position.y) / 10);
        distanceValue.text = PlayerProperties.distance.ToString();
        livesValue.text = PlayerProperties.playerLifes.ToString();
        gemsValue.text = PlayerProperties.playerGems.ToString();
    }
}
