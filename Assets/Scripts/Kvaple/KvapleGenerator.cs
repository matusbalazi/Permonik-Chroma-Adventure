using UnityEngine;
using static UnityEditor.PlayerSettings;

public class KvapleGenerator : MonoBehaviour
{
    [SerializeField] GameObject kvapel_Top;
    [SerializeField] GameObject kvapel_Bott;

    [SerializeField] Transform pos_Gr1;
    [SerializeField] Transform pos_Gr2;
    [SerializeField] Transform pos_Celing;
    void Start()
    {
        Vector3 top = new(
            pos_Celing.position.x + Random.Range((-pos_Celing.localScale.x / 2) + 30, (pos_Celing.localScale.x / 2) - 20),
            pos_Celing.position.y - 20 - pos_Celing.localScale.y / 2,
            pos_Celing.position.z - 5);
        Instantiate(kvapel_Top, top, Quaternion.identity, this.gameObject.transform);

        switch (Random.Range(0, 2))    {
            case 1: generateKvapel(pos_Gr1); break;
            case 2: generateKvapel(pos_Gr2); break;
            default: break;
        }              
    }
    void generateKvapel(Transform pos)
    {
        Vector3 bott = new(
            pos.position.x + Random.Range((-pos.localScale.x / 2) + 30, (pos.localScale.x / 2) - 20),
            pos.position.y + 20 + pos.localScale.y / 2,
            pos.position.z - 5);
        Instantiate(kvapel_Bott, bott, Quaternion.identity, this.gameObject.transform);
    }
}
