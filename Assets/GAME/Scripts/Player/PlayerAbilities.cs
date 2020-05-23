using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.VFX;


public class PlayerAbilities : MonoBehaviour
{

    private Transform canonOrigin;
    private Transform projectilesParent;
    private CameraShake cameraShake;

    [Space(5)]
    [Header("Ability Manager")]
    private Animator playerAnim;
    public Slider abilityQSlider;
    public Slider abilityESlider;
    public Slider abilityRSlider;
    [SerializeField] private bool isUsingAbility = false;

    [Space(5)]
    [Header("Ability Q property")]
    [SerializeField] private GameObject projectileQ;
    public float waitingTimeQ = 10f;
    public bool isAbilityQ = false;
    private GameObject AbilityQIdle;
    private float currentWaitingTimeValueQ = 0f;

    [Space(5)]
    [Header("Ability E property")]
    [SerializeField] private GameObject projectileE;
    [SerializeField] private float waitingTimeE = 20f;
    [SerializeField] private float invicibleTime = 10f;
    [SerializeField] private VisualEffect shieldParticles;
    public GameObject PreShield;
    private GameObject AbilityEIdle;
    private bool isAbilityE = false;
    public bool isInvicible = false;
    private float currentWaitingTimeValueE = 0f;

    [Space(5)]
    [Header("Ability R property")]
    [SerializeField] private GameObject projectileR;
    [SerializeField] private float waitingTimeR = 20f;
    public bool isAbilityR = false;
    private GameObject AbilityRIdle;
    private float currentWaitingTimeValueR = 0f;

    [Space(5)]
    [Header("Camera Shake Property")]
    [SerializeField] private float cameraShakeWaitUntil;
    public bool zoomCam = false;


  


    // Start is called before the first frame update
    void Start()
    {
        canonOrigin = GameObject.Find("CanonOrigin").transform;
        projectilesParent = GameObject.Find("Projectiles").transform;
        cameraShake = GameObject.Find("CameraHolder").GetComponent<CameraShake>();
        AbilityQIdle = GameObject.Find("AbilityLeftIdleQ");
        AbilityEIdle = GameObject.Find("AbilityLeftIdleE");
        AbilityRIdle = GameObject.Find("AbilityLeftIdleR");
        playerAnim = gameObject.GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isAbilityQ == false && isUsingAbility == false) {
            isUsingAbility = true;
            playerAnim.SetTrigger("TrigAbility01");
            StartCoroutine("DivineSword");
            StartCoroutine(LoadAbility(abilityQSlider, waitingTimeQ, currentWaitingTimeValueQ));
        }

        if(Input.GetKeyDown(KeyCode.E) && isAbilityE == false && isUsingAbility == false)
        {
            isUsingAbility = true;
            playerAnim.SetTrigger("TrigAbility02");
            StartCoroutine("InvicibleShield");
            StartCoroutine(LoadAbility(abilityESlider, waitingTimeE, currentWaitingTimeValueE));
        }

        if (Input.GetKeyDown(KeyCode.R) && isAbilityR == false && isUsingAbility == false) {
            isUsingAbility = true;
            playerAnim.SetTrigger("TrigAbility03");
            StartCoroutine("PhoenixThrow");
            StartCoroutine(LoadAbility(abilityRSlider, waitingTimeR, currentWaitingTimeValueR));
        }



    }

    public void ResetAnimationTime() {
        isUsingAbility = false;
    }

  


    IEnumerator DivineSword()
    {
        yield return new WaitForSeconds(.7f);
        //Spawn the DivineSword and wait until the player can again
        isAbilityQ = true;
        AbilityQIdle.SetActive(false);
        Instantiate(projectileQ, canonOrigin.position, Quaternion.identity, projectilesParent);
        yield return new WaitForSeconds(cameraShakeWaitUntil);
        cameraShake.triggerShake = true;

        yield return new WaitForSeconds(waitingTimeQ - cameraShakeWaitUntil -.7f);
        isAbilityQ = false;
        AbilityQIdle.SetActive(true);

    }


    IEnumerator InvicibleShield() {
        PreShield.SetActive(true);
        yield return new WaitForSeconds(.5f);
        isAbilityE = true;
        projectileE.SetActive(true);
        AbilityEIdle.SetActive(false);
        isInvicible = true;

        yield return new WaitForSeconds(invicibleTime);
        isInvicible = false;
        shieldParticles.Stop();

        yield return new WaitForSeconds(1.5f);
        projectileE.SetActive(false);
        PreShield.SetActive(false);

        yield return new WaitForSeconds(waitingTimeE - invicibleTime -0.5f);
        isAbilityE = false;
        AbilityEIdle.SetActive(true);
        

    }


    IEnumerator PhoenixThrow() {

        isAbilityR = true;
        AbilityRIdle.SetActive(false);
        zoomCam = true;
        yield return new WaitForSeconds(1f);
        zoomCam = false;
        GameObject currentPhoenixBlade = Instantiate(projectileR, canonOrigin.position, canonOrigin.rotation);
        currentPhoenixBlade.transform.SetParent(projectilesParent.parent);
        
        yield return new WaitForSeconds(waitingTimeR);
        isAbilityR = false;
        AbilityRIdle.SetActive(true);


    }


    IEnumerator LoadAbility(Slider abilitySlider, float maxWaitingTime, float currentValue)
    {

        abilitySlider.maxValue = maxWaitingTime;
   

        while (currentValue < maxWaitingTime)
        {

            currentValue += 1f;
            abilitySlider.value = currentValue;
            yield return new WaitForSeconds(1f);

        }

        if (currentValue >= maxWaitingTime -1)
        {
            Debug.Log("reset fucker");
            currentValue = 0f;
            abilitySlider.value = currentValue;
        }


    }


}
