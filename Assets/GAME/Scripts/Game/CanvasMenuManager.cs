using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMenuManager : MonoBehaviour
{
    public Animator animFade;
    public GameObject fadeElement;


    private void Start()
    {
        animFade = fadeElement.GetComponent<Animator>();
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    public void FadeSceneOverlay() {

        animFade.SetTrigger("Fade");

    }








}
