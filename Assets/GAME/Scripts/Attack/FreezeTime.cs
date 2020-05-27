using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : MonoBehaviour
{
    private bool waiting = false;


    public void StopFrame(float duration)
    {
        if (waiting == true)
        {
            return;
        }
        Time.timeScale = 0f;
        StartCoroutine(WaitFrame(duration));

    }


    IEnumerator WaitFrame(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
        waiting = false;

    }
}
