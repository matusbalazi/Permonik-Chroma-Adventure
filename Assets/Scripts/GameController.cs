using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private static int distance;
    [SerializeField] GameObject distanceValue;
    [SerializeField] GameObject lifesValue;
    [SerializeField] GameObject gemsValue;
    void Update()
    {
        distance = (int)((player.transform.position.x + player.transform.position.y)/10);
        if (distance < 0 ) 
            distance = 0;
        distanceValue.GetComponent<Text>().text = distance.ToString();
        lifesValue.GetComponent<Text>().text = PlayerProperties.playerLifes.ToString();
        gemsValue.GetComponent<Text>().text = PlayerProperties.playerGems.ToString();
    }

    public static int GetDistance()
    {
        return distance;
    }
}
