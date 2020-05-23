using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBetweenScene : MonoBehaviour
{


    public GameObject fadetransition;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = fadetransition.GetComponent<Animator>();

        StartCoroutine("StartFade");
    }

    IEnumerator StartFade() {

        yield return new WaitForSeconds(5f);

        FadeSceneOverlay();
    }


    public void FadeSceneOverlay()
    {

        anim.SetTrigger("Fade");

    }

}
