using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public bool isInDefaultPosition = true;
    public GameObject colorIndicator;
    public List<GameObject> stringsProjectiles = new List<GameObject>();
    private GameObject player;
    private float fireForce = 110f;
    private float distanceThreshold = 110f;
    private float remainingShootingTime;
    private float colorIndicatorTime;
    private Color randomColor;
    private bool wasColorChose = false;
    private int numberOfShots;
    private bool stringsWereDestroyed = true;

    private void Start()
    {
        player = GameObject.Find("Player");
        numberOfShots = stringsProjectiles.Count;
        remainingShootingTime = Random.Range(0.8f, 2f);
        colorIndicatorTime = Random.Range(0.6f, remainingShootingTime);
        colorIndicator.GetComponent<SkinnedMeshRenderer>().material.color = colorIndicator.GetComponent<SkinnedMeshRenderer>().materials[0].color;
    }

    void Update()
    {
        if (player.GetComponent<Rigidbody2D>().position.x >= transform.position.x)
        {
            isInDefaultPosition = false;
        }

        if (player.GetComponent<Rigidbody2D>().position.x <= transform.position.x)
        {
            isInDefaultPosition = true;
        }

        float distance = player.GetComponent<Rigidbody2D>().position.x - transform.position.x;

        if ((Mathf.Abs(distance) < distanceThreshold) && numberOfShots > 0)
        {
            if (remainingShootingTime >= 0)
            {
                if (!wasColorChose)
                {
                    wasColorChose = true;
                    randomColor = Colors.GetRandomColor();
                }

                if (colorIndicatorTime >= 0)
                {
                    colorIndicatorTime -= Time.deltaTime;
                }

                if (colorIndicatorTime <= 0)
                {
                    colorIndicator.GetComponent<SkinnedMeshRenderer>().material.color = randomColor;
                    colorIndicatorTime = Random.Range(0.6f, remainingShootingTime);
                }

                remainingShootingTime -= Time.deltaTime;
            }

            if (remainingShootingTime <= 0 && (stringsProjectiles.Count - 1) >= 0 && stringsWereDestroyed)
            {
                colorIndicator.GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
                wasColorChose = false;
                stringsWereDestroyed = false;             
                stringsProjectiles[stringsProjectiles.Count - 1].GetComponentInChildren<SkinnedMeshRenderer>().material.color = randomColor;
                stringsProjectiles[stringsProjectiles.Count - 1].SetActive(true);
                stringsProjectiles[stringsProjectiles.Count - 1].GetComponent<Rigidbody2D>().gravityScale = 1;
                stringsProjectiles[stringsProjectiles.Count - 1].GetComponent<Rigidbody2D>().AddForce((isInDefaultPosition ? Vector2.left : Vector2.right) * fireForce, ForceMode2D.Impulse);
                stringsProjectiles[stringsProjectiles.Count - 1].transform.SetParent(null);
                StartCoroutine(DestroyStrings());               
                remainingShootingTime = Random.Range(0.8f, 2f);
                colorIndicatorTime = Random.Range(0.6f, remainingShootingTime);
                numberOfShots--;
            }
        }
        else
        {
            colorIndicator.GetComponent<SkinnedMeshRenderer>().material.color = Color.white;
            wasColorChose = false;
            remainingShootingTime = Random.Range(0.8f, 2f);
            colorIndicatorTime = Random.Range(0.6f, remainingShootingTime);     
        }
    }

    IEnumerator DestroyStrings()
    {
        yield return new WaitForSeconds(3f);
        Destroy(stringsProjectiles[stringsProjectiles.Count - 1]);
        stringsProjectiles.RemoveAt(stringsProjectiles.Count - 1);
        stringsWereDestroyed = true;
    }
}
