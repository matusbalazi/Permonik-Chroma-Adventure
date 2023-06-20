using UnityEngine;

public class SpawnCollectable : MonoBehaviour
{
    public enum CollectableType { gem, life, boost };
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
            Type = CollectableType.boost;
        }
        else
        {
            transform.Find("Gem").gameObject.SetActive(true);
            Type = CollectableType.gem;
        }
    }
}
