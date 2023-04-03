using UnityEngine;

public class Section : MonoBehaviour
{
    [SerializeField] private int endsOnLvl;
    public int GetEndsOnLvl()
        => endsOnLvl;
}
