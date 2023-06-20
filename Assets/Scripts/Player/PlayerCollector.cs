using Unity.VisualScripting;
using UnityEngine;
using static SpawnCollectable;

public class PlayerCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            switch (other.GetComponent<SpawnCollectable>().Type)
            {
                case CollectableType.gem:
                    PlayerProperties.playerGems++;
                    break;
                case CollectableType.life:
                    PlayerProperties.playerLifes++;
                    break;
                default:
                    Debug.Log("Nieco ine");
                    break;
            }
            other.gameObject.SetActive(false);
        }
    }
}
