using Unity.VisualScripting;
using UnityEngine;

public class Section : MonoBehaviour
{
    [SerializeField] private int endsOnLvl;
    public int GetEndsOnLvl()
        => endsOnLvl;

    private void Update()
    {
        if (WaterRise.WaterPos.y > transform.position.y + 200)
            Destroy(gameObject);
    }
}
