using UnityEngine;

public class RotateCollectable : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    private Vector3 rotation;
    private void Start()
    {
        rotation = new Vector3(0, 10, 0);
    }
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime * rotation);
    }
}
