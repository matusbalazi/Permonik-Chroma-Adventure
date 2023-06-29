using UnityEngine;

public class KvapleGenerator : MonoBehaviour
{
    // prefabs
    [SerializeField] GameObject kvapel_Top;
    [SerializeField] GameObject kvapel_Bott;

    // positions
    [SerializeField] Transform pos_Gr1;
    [SerializeField] Transform pos_Gr2;
    [SerializeField] Transform pos_Ceil1;
    [SerializeField] Transform pos_Ceil2;

    // location range
    [SerializeField] int leftToRight;
    void Start()
    {
        if (pos_Ceil1 == null && pos_Ceil2 != null)
            GenerateOnCeiling(pos_Ceil2);
        else if (pos_Ceil2 == null && pos_Ceil1 != null) 
            GenerateOnCeiling(pos_Ceil1);
        else if (pos_Ceil1 != null && pos_Ceil2 != null)
            switch (Random.Range(0, 2))
            {
                case 1: GenerateOnCeiling(pos_Ceil1); break;
                case 2: GenerateOnCeiling(pos_Ceil2); break;
                default: break;
            }
        

        if (pos_Gr1 == null && pos_Gr2 != null)
            GenerateOnGround(pos_Gr2);
        else if (pos_Gr2 == null && pos_Gr1 != null)
            GenerateOnGround(pos_Gr1);
        else if (pos_Gr1 != null && pos_Gr2 != null)
            switch (Random.Range(0, 2))
            {
                case 1: GenerateOnGround(pos_Gr1); break;
                case 2: GenerateOnGround(pos_Gr2); break;
                default: break;
            }
    }
    void GenerateOnGround(Transform pos)
    {
        Vector3 bott = new(
            pos.position.x + Random.Range((-pos.localScale.x + 20) / 2 , pos.localScale.x - 20 / 2 ),
            pos.position.y + 70,
            5);
        Instantiate(kvapel_Bott, bott, Quaternion.identity, transform);
    }
    void GenerateOnCeiling(Transform pos)
    {
        Vector3 top = new(
            pos.position.x + Random.Range(-leftToRight, leftToRight),
            pos.position.y - 25,
            5);
        Instantiate(kvapel_Top, top, Quaternion.identity, transform);
    }
}
