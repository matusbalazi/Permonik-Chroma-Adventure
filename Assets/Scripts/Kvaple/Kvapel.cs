using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kvapel : MonoBehaviour
{
    [SerializeField] List <Sprite> kvapleBank;
    void Start()
    {        
        GetComponent<SpriteRenderer>().sprite = kvapleBank[Random.Range(0, kvapleBank.Count)];
    }
}
