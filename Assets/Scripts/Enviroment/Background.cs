using UnityEngine;

public class Background : MonoBehaviour
{
    private float startPosY;
    [SerializeField] GameObject camera;
    void Awake()
    {
        startPosY = transform.position.y;
    }

    void Update()
    {
        float distanceY = camera.transform.position.y-45;
        transform.position = new Vector3(
            transform.position.x,
            startPosY + (distanceY / 0.99995f), 
            transform.position.z);
    }
}
