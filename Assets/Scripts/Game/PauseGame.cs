using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("StartButtonPause"))
        {
            GameProperties.isPaused = !GameProperties.isPaused;
            LaunchPause();
        }
    }

    private void LaunchPause()
    {
        if (GameProperties.isPaused)
        {
            // do something
        } 
        else
        {
            // do something different
        }
    }
}
