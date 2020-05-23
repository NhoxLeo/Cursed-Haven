using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class handAttackMelee : MonoBehaviour
{
    [Header("Enemy Melee properties")]
    private EnnemyFollowPlayer enemyFollowPlayer;
    public GameObject enemyMelee;
    public bool readyToAttack = true;


    [Space(5)]
    [Header("Damage dealer popop")]
    [SerializeField] private GameObject damagePop;
    [SerializeField] private float minMeleeDamage = 30f;
    [SerializeField] private float maxMeleeDamage = 40f;
    [SerializeField] private int randomMeleeDamage;
    [SerializeField] private float offestY = 2f;
    [SerializeField] private float minAngle = -10f;
    [SerializeField] private float maxAngle = 10f;
    private TextMeshPro damageText;

  
    private PlayerAbilities playerAbilities; // detect if invicible;
    private PlayerHealthSystem playerhealthSystem; // get current player health;
    private CameraShake cameraShake; // trigger the camera shake;





    // Start is called before the first frame update
    void Start()
    {
        playerAbilities = GameObject.Find("BoneKnightIdle").GetComponent<PlayerAbilities>(); //Change name for future gameplay bro
        playerhealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
        cameraShake = GameObject.Find("CameraHolder").GetComponent<CameraShake>();
        enemyFollowPlayer = enemyMelee.GetComponent<EnnemyFollowPlayer>();
    }



    public int RandomMeleeDamage()
    {
        // Randomize the default damage from the bullet
        randomMeleeDamage = Mathf.FloorToInt(Random.Range(minMeleeDamage, maxMeleeDamage));
        return randomMeleeDamage;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" && enemyFollowPlayer.hasToAttack == true && readyToAttack == true) {

            StartCoroutine("DelayAttack");
            cameraShake.triggerShake = true;
            GameObject GODamagePop = Instantiate(damagePop, new Vector3(other.transform.position.x, other.transform.position.y + offestY, other.transform.position.z), Quaternion.identity);
            damageText = damagePop.GetComponentInChildren<TextMeshPro>();
            damageText.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(minAngle, maxAngle)));
            StartCoroutine("DelayAttack");



            if (playerAbilities.isInvicible == false)
            {
                //Do damage
                playerhealthSystem.currentHealthValue -= RandomMeleeDamage();
                damageText.text = RandomMeleeDamage().ToString();
                Destroy(GODamagePop, 1f);


            }
            else
            {
                //is invincible
                damageText = damagePop.GetComponentInChildren<TextMeshPro>();
                damageText.text = "Dodge";
                Destroy(GODamagePop, 1f);
            }
        }
    }


    IEnumerator DelayAttack() {
        readyToAttack = false;
        yield return new WaitForSeconds(0.7f);
        readyToAttack = true;



    }




}
