using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] private Transform posL, posR;
    [SerializeField] private float speed = 30;
    [SerializeField] private int borders;
    private Vector2 targetPos;

    private void Start()
    {
        targetPos = posR.position;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, posR.position) < borders)
            targetPos = posL.position;
        if (Vector2.Distance(transform.position, posL.position) < borders)
            targetPos = posR.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.transform.SetParent(null);
    }
    */

}
