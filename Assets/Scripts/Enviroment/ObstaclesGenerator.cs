using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField] GameObject obstacle;
    [SerializeField] Transform position1;
    [SerializeField] Transform position2;
    void Start()
    {
        if (PlayerProperties.distance > 50)
        {
            switch (Random.Range(1, 10))
            {
                case 8:
                    if (position1 != null)
                        Generate(position1);
                    break;

                case 9:
                    if (position2 != null)
                        Generate(position2);
                    break;

                case 10:
                    if (position1 != null)
                        Generate(position1);
                    if (position2 != null)
                        Generate(position2);
                    break;

                default: break;
            }
        }
    }
    private void Generate(Transform position)
    {
        position.position = new Vector3(
                    position.position.x + Random.Range(-15, 15),
                    position.position.y,
                    position.position.z
                );
        Instantiate(obstacle, position);

    }
}

