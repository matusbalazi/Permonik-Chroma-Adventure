using UnityEngine;

public class SpawnCollectable : MonoBehaviour
{
    public enum CollectableType { gem, life, speedBoost, speedSlow, longStick };
    public CollectableType Type { get; set; }

    void Start()
    {
        int rnd = RandomNumberGenerator.GetRandomInt();

        if (rnd <= 5)
        {
            transform.Find("Life").gameObject.SetActive(true);
            Type = CollectableType.life;
        }
        else if (rnd <= 45)
        {
            transform.Find("QueMark").gameObject.SetActive(true);
            switch (Random.Range(0, 2))
            {
                case 0:
                    Type = CollectableType.speedBoost;
                    break;
                case 1:
                    Type = CollectableType.speedSlow;
                    break;
                case 2:
                    Type = CollectableType.longStick;
                    break;
                default:
                    Debug.Log("Spawnla sa dalsia moznost");
                    break;
            }
        }
        else
        {
            transform.Find("Gem").gameObject.SetActive(true);
            Type = CollectableType.gem;
        }
    }
}
