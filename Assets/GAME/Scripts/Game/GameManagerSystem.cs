using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManagerSystem : MonoBehaviour
{


    [Header("Post Process Volume properties")]
    public Volume PPPVolumne;
    private DepthOfField dof;
    [SerializeField] private float focalLengthTemp = 180f;
    [SerializeField] private float apertureTemp = 20f;
    [SerializeField] private float focusDistTemp = 5f;
    [SerializeField] private GameObject settingsCanvas;
    private Animator settingsAnim;
    private bool activateFlou = false;
    private bool isNullFlou = true;
    private float speedLerp = 0f;

    private int state = 1;
    public GameObject overlayBG;
    public  Animator animOverlay;
    public bool isPaused = false;
    private bool trigSettings = false;


    [Space(5)]
    [Header("Player GameOver")]
    [SerializeField] private GameObject player;
    private PlayerHealthSystem playerHealthSystem;
    private bool triggerDyingTransiton = false;
    public GameObject gameOverUI;




    void Start()
    {    
        PPPVolumne.profile.TryGet(out dof);
        settingsCanvas.SetActive(false);
        animOverlay = overlayBG.GetComponent<Animator>();
        settingsAnim = settingsCanvas.GetComponent <Animator>();


        //Game over component needed
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthSystem = player.GetComponent<PlayerHealthSystem>();
    }


    void Update()
    {  

        if (Input.GetKeyDown(KeyCode.Escape) && triggerDyingTransiton == false) {
            trigSettings = true;
            isNullFlou = false;
            IncreaseFlou();
            StartCoroutine("FreezeTime");

        }


        if (isNullFlou == false)
        {
            increaseOverlay();
        }

        DetectGameOver();

    }


    public void DetectGameOver() {

        if (playerHealthSystem.currentHealthValue <= 0) {

            //This is GameOver, the player is dead and have no more health
            isNullFlou = false;


            if (triggerDyingTransiton == false) {
                IncreaseFlou();
                StartCoroutine("FreezeTime");
                triggerDyingTransiton = true;
            }
            
            
            

        }
    
    
    }


    public void increaseOverlay() {

        if (activateFlou == true)
        {
            dof.focalLength.value = Mathf.Lerp(focalLengthTemp, 300f, speedLerp);
            dof.aperture.value = Mathf.Lerp(apertureTemp, 0f, speedLerp);
            dof.focusDistance.value = Mathf.Lerp(focusDistTemp, 1f, speedLerp);
            speedLerp += 1f * Time.deltaTime;
           
        }
        else
        {
            dof.focalLength.value = Mathf.Lerp(300f, focalLengthTemp, speedLerp);
            dof.aperture.value = Mathf.Lerp(0f, apertureTemp, speedLerp);
            dof.focusDistance.value = Mathf.Lerp(1f, focusDistTemp, speedLerp);
            speedLerp += 1f * Time.deltaTime;
          
        }

    }

    IEnumerator FreezeTime() {

        if (activateFlou == true)
        {
            yield return new WaitForSeconds(2f);
            Time.timeScale = 0f; //pause game
            Debug.Log("rsbdvcbsivbd");

        }
        else {
          
            Debug.Log("return ye");
            Time.timeScale = 1f; //pause game
        }



    }






    public void IncreaseFlou() {


        switch (state) {

            case 1:
                
                speedLerp = 0f;
                activateFlou = true;
                animOverlay.SetBool("TriggerIn", true);
                animOverlay.SetBool("TriggerOut", false);
                settingsAnim.SetBool("isPaused", true);

                if (trigSettings == true)
                {
                    settingsCanvas.SetActive(true);
                }
                else {

                    gameOverUI.SetActive(true);
                }
                
                state++;
                
                break;


            case 2:
               
                speedLerp = 0f;
                activateFlou = false;
                animOverlay.SetBool("TriggerIn", false);
                animOverlay.SetBool("TriggerOut", true);
                settingsAnim.SetBool("isPaused", false);
                trigSettings = false;
                state--;
                
                break;
        }
      
    }



}
