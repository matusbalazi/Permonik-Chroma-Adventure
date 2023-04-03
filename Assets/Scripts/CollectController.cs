using UnityEngine;
using UnityEngine.UI;

public class CollectController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            if (collision.gameObject.name == "Gem")
            {
                PlayerProperties.playerGems++;                
            }
            collision.gameObject.SetActive(false);
        }            
    }
}
