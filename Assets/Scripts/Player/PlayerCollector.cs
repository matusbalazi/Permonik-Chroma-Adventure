using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static SpawnCollectable;

public class PlayerCollector : MonoBehaviour
{
    public static bool isSpeedModified = false;
    public static bool isStickModified = false;

    public AudioSource gemSFX;
    public AudioSource pickUpSFX;
    public AudioSource pickDownSFX;
    public AudioSource newLifeSFX;

    [SerializeField] private GameObject powerUpHUD;

    [SerializeField] private Sprite speedBoost;
    [SerializeField] private Sprite speedSlow;
    [SerializeField] private Sprite longStick;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            switch (other.GetComponent<SpawnCollectable>().Type)
            {
                case CollectableType.gem:
                    if (!gemSFX.isPlaying)
                    {
                        gemSFX.Play();
                    }

                    PlayerProperties.gems++;
                    break;
                case CollectableType.life:
                    if (!newLifeSFX.isPlaying)
                    {
                        newLifeSFX.Play();
                    }

                    PlayerProperties.lives++;               
                    break;

                case CollectableType.speedBoost:
                    if (!pickUpSFX.isPlaying)
                    {
                        pickUpSFX.Play();
                    }

                    StartCoroutine(SetPowerUpHUD("Speed Boost", null));
                    StartCoroutine(ModifySpeed(10, 180));
                    break;

                case CollectableType.speedSlow:
                    if (!pickDownSFX.isPlaying)
                    {
                        pickDownSFX.Play();
                    }

                    StartCoroutine(SetPowerUpHUD("Speed Slow", null));
                    StartCoroutine(ModifySpeed(5, 80));                    
                    break;

                case CollectableType.longStick:
                    if (!pickUpSFX.isPlaying)
                    {
                        pickUpSFX.Play();
                    }

                    StartCoroutine(SetPowerUpHUD("Infinite Stick", null));
                    StartCoroutine(ModifyStick(20,200));
                    break;

                default:
                    Debug.Log("Nieco ine");
                    break;
            }
            other.gameObject.SetActive(false);
        }
    }
    private IEnumerator ModifySpeed(float time, int speed)
    {
        float originalSpeed = PlayerProperties.speedForce;
        isSpeedModified = true;
        PlayerProperties.speedForce = speed;
        yield return new WaitForSeconds(time);
        isSpeedModified = false;
        PlayerProperties.speedForce = originalSpeed;
    }

    private IEnumerator ModifyStick(float time, int stickTime)
    {
        float originalStickTime = PlayerProperties.remainingStickTime; 
        isStickModified = true;
        PlayerProperties.remainingStickTime = stickTime;
        yield return new WaitForSeconds(time);
        isStickModified = false;
        PlayerProperties.remainingStickTime = originalStickTime;
    }
    private IEnumerator SetPowerUpHUD(string text, Sprite sprite)
    {
        powerUpHUD.SetActive(true);
        powerUpHUD.GetComponent<Text>().text = text;
        yield return new WaitForSeconds(2);
        //powerUpHUD.transform.Find("PowerUpImg").GetComponent<SpriteRenderer>().sprite = sprite;
        powerUpHUD.SetActive(false);
    }
}
