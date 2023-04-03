using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionBank : MonoBehaviour
{
    [SerializeField] private List<Section> sectionsEasy;
    [SerializeField] private List<Section> sectionsMedium;
    [SerializeField] private List<Section> sectionsHard;    
    
    public List<Section> GetSectionsEasy() { return sectionsEasy; }
    public List<Section> GetSectionsMedium() { return sectionsMedium; }
    public List<Section> GetSectionsHard() { return sectionsHard; }
}
