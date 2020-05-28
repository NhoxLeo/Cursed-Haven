using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoosterProprieties : MonoBehaviour
{

    private BoosterManager boosterManager;
    private PlayerHealthSystem playerHealSystem;
    
    [Header("Heal properties")]
    public int boostHealhValue;
    [SerializeField] private Animator anim;
    [SerializeField] private float delayBeforeDie = 2f;
    public GameObject vfxImpact;
    public GameObject vfxHeal;
    private GameObject player;
    private GameObject powerUp;

    // Start is called before the first frame update
    void Start()
    {
        boosterManager = GameObject.Find("SpawnPowerUp").GetComponent<BoosterManager>();
        playerHealSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
        anim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        powerUp = GameObject.Find("PowerUp");




        // Get 33% heal boost
        boostHealhValue = Mathf.FloorToInt(playerHealSystem.maxHealthValue / 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (vfxHeal != null) {

            vfxHeal.transform.position = player.transform.position;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Environment") {
            vfxImpact.SetActive(true);
        }


        if (other.transform.tag == "Player") {

            boosterManager.alreadyHaveBooster = false;


            if (playerHealSystem.currentHealthValue < playerHealSystem.maxHealthValue) {

                if ((playerHealSystem.currentHealthValue + boostHealhValue) > playerHealSystem.maxHealthValue)
                {
                    playerHealSystem.currentHealthValue = playerHealSystem.maxHealthValue;
                }
                else
                {
                    playerHealSystem.currentHealthValue += boostHealhValue;
                }


            }

            anim.SetBool("isCloseToPlayer", true);
            GameObject healEffect = Instantiate(vfxHeal, player.transform.position, Quaternion.identity);

            //Mike met ton son de Chest qui open;

            healEffect.transform.parent = player.transform;
            Destroy(healEffect, 4f);
            powerUp.transform.GetChild(0).gameObject.SetActive(true);
            StartCoroutine("DisableBooster");
            Destroy(transform.parent.gameObject, delayBeforeDie);
           
        }
    }



    IEnumerator DisableBooster() {

        yield return new WaitForSeconds(3f);
        powerUp.transform.GetChild(0).gameObject.SetActive(false);

    }


}
