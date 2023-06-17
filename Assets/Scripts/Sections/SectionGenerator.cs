using System.Collections.Generic;
using UnityEngine;

public class SectionGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bank;
    [SerializeField] private Transform lastSectionPosition;
    [SerializeField] private GameObject nextSectionsTrigger;

    private Vector3 newPosition;
    private int section = 1;
    private int lvl = 0;
    private SectionBank localBank;

    [SerializeField] List<GameObject> sectionsPool;

    private void Start()
    {
        newPosition = lastSectionPosition.position;
        localBank = bank.GetComponent<SectionBank>();
        sectionsPool = localBank.GetSectionsEasy();
    }
    private void Update()
    {
        if (PlayerProperties.score == 500)
            sectionsPool.AddRange(localBank.GetSectionsMedium());
        else if (PlayerProperties.score == 1500)
            sectionsPool.AddRange(localBank.GetSectionsHard());

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerProperties.Checkpoint = transform.position;

        if (!collision.CompareTag("Player"))
        {
            return;
        }

        if (lastSectionPosition.GetComponent<Section>().GetEndsOnLvl() > 0)
        {
            lvl += 100 * lastSectionPosition.GetComponent<Section>().GetEndsOnLvl();
        }
        GameObject nextSectionGenerator = null;
        for (int i = 0; i <= 5; i++)
        {
            GameObject nextSection = sectionsPool[Random.Range(0, sectionsPool.Count)];
            newPosition = lastSectionPosition.position + new Vector3(300 * section, lvl, 0);

            Transform tr = Instantiate(nextSection, newPosition, Quaternion.identity).transform;

            if (i == 3)
                nextSectionGenerator = Instantiate(nextSectionsTrigger,
                    newPosition + new Vector3(-150, 30, 0), Quaternion.identity);

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
        {
            lvl += adjustment;
        }
    }

    public void SetLastSectionPosition(Transform lastSection)
    {
        this.lastSectionPosition = lastSection;
    }
}
