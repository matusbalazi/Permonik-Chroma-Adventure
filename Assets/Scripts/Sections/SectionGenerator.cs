using System.Collections.Generic;
using UnityEngine;

public class SectionGenerator : MonoBehaviour
{
    [SerializeField] private SectionBank bank;
    [SerializeField] private Transform lastSectionPosition;
    [SerializeField] private List<GameObject> sectionsPool;

    private Vector3 newPosition;
    private int section = 1, lvl = 0;
    public static int
        breakPoint1 = 100,
        breakPoint2 = 200,
        breakPoint3 = 300;

    private void Start()
    {
        sectionsPool = new List<GameObject>();
        newPosition = lastSectionPosition.position;

        if (PlayerProperties.distance <= breakPoint1)
        {
            sectionsPool.AddRange(bank.GetSectionsEasy());
        }
        else if (PlayerProperties.distance > breakPoint1 && PlayerProperties.distance <= breakPoint2)
        {
            sectionsPool.AddRange(bank.GetSectionsEasy());
            sectionsPool.AddRange(bank.GetSectionsMedium());
        }
        else if (PlayerProperties.distance > breakPoint2 && PlayerProperties.distance <= breakPoint3)
        {
            sectionsPool.AddRange(bank.GetSectionsEasy());
            sectionsPool.AddRange(bank.GetSectionsMedium());
            sectionsPool.AddRange(bank.GetSectionsHard());
        }
        else if (PlayerProperties.distance > breakPoint3)
        {
            sectionsPool.AddRange(bank.GetSectionsMedium());
            sectionsPool.AddRange(bank.GetSectionsHard());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerProperties.Checkpoint = transform.position;

        if (!collision.CompareTag("Player"))
            return;

        if (lastSectionPosition.GetComponent<Section>().GetEndsOnLvl() > 0)
            lvl += 100 * lastSectionPosition.GetComponent<Section>().GetEndsOnLvl();

        GameObject nextSectionGenerator = null;
        for (int i = 0; i <= 5; i++)
        {
            GameObject nextSection = sectionsPool[Random.Range(0, sectionsPool.Count)];
            newPosition = lastSectionPosition.position + new Vector3(300 * section, lvl, 0);

            Transform tr = Instantiate(nextSection, newPosition, Quaternion.identity).transform;

            if (i == 3)
            {
                nextSectionGenerator = Instantiate(gameObject,
                    newPosition + new Vector3(-150, 30, 0), Quaternion.identity);
            }

            IncreaseLvl(nextSection);
            section++;

            if (i == 5 && section > 1)
                nextSectionGenerator.GetComponent<SectionGenerator>().SetLastSectionPosition(tr);
        }
        Destroy(gameObject);
    }

    private void IncreaseLvl(GameObject nextSection)
    {
        Dictionary<int, int> lvlAdjustments = new() {
            {-3, -300},
            {-2, -200},
            {-1, -100},
            {1, 100},
            {2, 200},
            {3, 300}
        };

        Section section = nextSection.GetComponent<Section>();
        if (lvlAdjustments.TryGetValue(section.GetEndsOnLvl(), out int adjustment))
            lvl += adjustment;
    }

    public void SetLastSectionPosition(Transform lastSection)
    {
        lastSectionPosition = lastSection;
    }
    public static int Lvl { get; }
}
