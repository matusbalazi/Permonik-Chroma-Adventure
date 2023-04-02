using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlatformProperties : MonoBehaviour
{
    public bool isStickable = false;
    public Color platformColor;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.isStickable)
        {
            PlayerProperties.isStickActive = true;
            Debug.Log("Stick activated");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && this.isStickable)
        {
            PlayerProperties.isStickActive = false;
            Debug.Log("Stick deactivated");
        }
    }
}
