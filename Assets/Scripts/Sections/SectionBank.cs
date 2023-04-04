using System.Collections.Generic;
using UnityEngine;

public class SectionBank : MonoBehaviour
{
    [SerializeField] private List<GameObject> sectionsEasy;
    [SerializeField] private List<GameObject> sectionsMedium;
    [SerializeField] private List<GameObject> sectionsHard;

    public List<GameObject> GetSectionsEasy() { return sectionsEasy; }
    public List<GameObject> GetSectionsMedium() { return sectionsMedium; }
    public List<GameObject> GetSectionsHard() { return sectionsHard; }
}
