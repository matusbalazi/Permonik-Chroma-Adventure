using UnityEngine;
using UnityEngine.EventSystems;

public class SelectButtonOnEnable : MonoBehaviour
{
    [SerializeField] private GameObject button;

    public void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(button);
    }
}
