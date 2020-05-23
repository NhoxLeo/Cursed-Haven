using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTheGame : MonoBehaviour
{
   
    public Animator anim;
    public int levelToLoad = 1;
    // Start is called before the first frame update





    public void Fadelevel(int levelIndex) {

        levelToLoad = levelIndex;
        anim.SetTrigger("Fade");

    }

    public void FadeCompleted() {

        SceneManager.LoadScene(levelToLoad);
    }
  
    
}
