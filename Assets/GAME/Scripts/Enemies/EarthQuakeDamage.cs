using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EarthQuakeDamage : MonoBehaviour
{


    [Header("EarthQuake properties")]
    [SerializeField] float speed = 1.5f;
    private Vector3 targetPos;
    public int randomDefaultDamage;
    public float defaultMinAttackDamage = 35f;
    public float defaultMaxAttackDamage = 55f;
    private PlayerAbilities playerAbilities;
    private PlayerHealthSystem playerhealthSystem;


    [Space(5)]
    [Header("Damage dealer poppop")]
    [SerializeField] private GameObject damagePop;
    [SerializeField] private float offestY;
    [SerializeField] private float minAngle = -10f;
    [SerializeField] private float maxAngle = 10f;
    private TextMeshPro damageText;


    private CameraShake cameraShake;



    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5f);


        playerAbilities = GameObject.Find("BoneKnightIdle").GetComponent<PlayerAbilities>(); //Change name for future gameplay bro
        playerhealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
        cameraShake = GameObject.Find("CameraHolder").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }



    public int RandomDefaultDamage()
    {
        // Randomize the default damage from the bullet
        randomDefaultDamage = Mathf.FloorToInt(Random.Range(defaultMinAttackDamage, defaultMaxAttackDamage));
        return randomDefaultDamage;
    }




    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {

            Debug.Log("jte touche");

            cameraShake.triggerShake = true;
            GameObject GODamagePop = Instantiate(damagePop, new Vector3(other.transform.position.x, other.transform.position.y + offestY, other.transform.position.z), Quaternion.identity);
            damageText = damagePop.GetComponentInChildren<TextMeshPro>();
            damageText.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(minAngle, maxAngle)));


            if (playerAbilities.isInvicible == false)
            {
                //Do damage
                playerhealthSystem.currentHealthValue -= RandomDefaultDamage();
                damageText.text = RandomDefaultDamage().ToString();
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
}
