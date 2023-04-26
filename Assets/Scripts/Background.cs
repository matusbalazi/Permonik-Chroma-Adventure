using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float startPosX, startPosY;
    [SerializeField] GameObject camera;
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    void Update()
    {
        float distanceX = camera.transform.position.x;
        float distanceY = camera.transform.position.y;
        transform.position = new Vector3(startPosX + (distanceX/1.1f), startPosY + (distanceY/0.8f), transform.position.z);        
    }
}
