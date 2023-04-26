using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Text distanceValue;
    [SerializeField] Text livesValue;
    [SerializeField] Text gemsValue;

    void Update()
    {
        int distance = (int)((player.transform.position.x + player.transform.position.y) / 10);
        PlayerProperties.distance = distance >= 0 ? distance : 0;
        distanceValue.text = PlayerProperties.distance.ToString();
        livesValue.text = PlayerProperties.playerLifes.ToString();
        gemsValue.text = PlayerProperties.playerGems.ToString();
    }
}
