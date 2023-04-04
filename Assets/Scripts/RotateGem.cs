using UnityEngine;

public class RotateGem : MonoBehaviour
{
    [SerializeField] float speed = 20;
    Vector3 rotation;
    private void Start()
    {
        rotation = new Vector3(0, 10, 0);
    }
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime * rotation);
    }
}
