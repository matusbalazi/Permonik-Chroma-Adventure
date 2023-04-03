using System.Collections.Generic;
using UnityEngine;

public class SectionGenerator : MonoBehaviour
{
    [SerializeField] private SectionBank bank;
    [SerializeField] private Transform lastSectionPosition;
    [SerializeField] private GameObject nextSectionsTrigger;

    private Vector3 newPosition;
    private int section = 1, lvl = 0;
    private SectionBank localBank;

    [SerializeField] List<Section> sectionsPool;

    private void Start()
    {
        newPosition = lastSectionPosition.position;
        localBank = bank.GetComponent<SectionBank>();
        sectionsPool = localBank.GetSectionsEasy();
    }
    private void Update()
    {
        float distance = GameController.GetDistance();        
        if (distance == 500)
            sectionsPool.AddRange(localBank.GetSectionsMedium());
        else if (distance == 1500)
            sectionsPool.AddRange(localBank.GetSectionsHard());
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (lastSectionPosition.GetComponent<Section>().GetEndsOnLvl() > 0)
            {
                lvl += 100* lastSectionPosition.GetComponent<Section>().GetEndsOnLvl();
            }
            GameObject nextSectionGenerator = null;
            for (int i = 0; i <= 5; i++)
            {
                Section nextSection = sectionsPool[Random.Range(0, sectionsPool.Count)];
                newPosition = lastSectionPosition.position + new Vector3(300 * section, lvl, 0);

                Transform tr = Instantiate(nextSection, newPosition, Quaternion.identity).transform;

                if (i == 3)
                    nextSectionGenerator = Instantiate(nextSectionsTrigger, newPosition + new Vector3(-150, 30, 0), Quaternion.identity);

                IncreaseLvl(nextSection);
                section++;

                if (i == 5 && section > 1)
                    nextSectionGenerator.GetComponent<SectionGenerator>().SetLastSectionPosition(tr);
            }
            Destroy(gameObject);
        }
    }

    private void IncreaseLvl(Section nextSection)
    {
        switch (nextSection.GetComponent<Section>().GetEndsOnLvl())
        {
            case -3:
                lvl -= 300;
                break;
            case -2:
                lvl -= 200;
                break;
            case -1:
                lvl -= 100;
                break;

            case 1:
                lvl += 100;
                break;
            case 2:
                lvl += 200;
                break;
            case 3:
                lvl += 300;
                break;

            default:
                lvl += 0;
                break;
        }
    }

    public void SetLastSectionPosition(Transform lastSection)
    {
        this.lastSectionPosition = lastSection;
    }
}
