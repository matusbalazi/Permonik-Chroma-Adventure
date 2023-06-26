using System.Collections;
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
                    PlayerProperties.gems++;
                    break;
                case CollectableType.life:
                    PlayerProperties.lives++;
                    break;

                case CollectableType.speedBoost:
                    Debug.Log(CollectableType.speedBoost);
                    float helpSB = PlayerProperties.speedForce;
                    PlayerProperties.speedForce = 200;
                        StartCoroutine(Wait(5));
                    PlayerProperties.speedForce = helpSB;
                    break;

                case CollectableType.speedSlow:
                    Debug.Log(CollectableType.speedSlow);
                    float helpSS = PlayerProperties.speedForce;
                    PlayerProperties.speedForce = 50;
                        StartCoroutine(Wait(5));
                    PlayerProperties.speedForce = helpSS;
                    break;

                case CollectableType.longStick:
                    Debug.Log(CollectableType.longStick);
                    float helpLS = PlayerProperties.remainingStickTime;
                    PlayerProperties.remainingStickTime = 200;
                        StartCoroutine(Wait(20));
                    PlayerProperties.remainingStickTime = helpLS;
                    break;

                default:
                    Debug.Log("Nieco ine");
                    break;
            }
            other.gameObject.SetActive(false);
        }
    }

    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
