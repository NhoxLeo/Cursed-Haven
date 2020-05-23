using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isPaused;
    public void PauseTheGame()
    {

        if (isPaused)
        {

            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {

            Time.timeScale = 0;
            isPaused = true;
        }
    }

}
