using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyBullet : MonoBehaviour
{

    [Header("Bullet proprieties")]
    [SerializeField] private float speed = 8f;
    private Transform targetPlayer;
    private Vector3 target;
    public int randomDefaultDamage;
    public float defaultMinAttackDamage = 20f;
    public float defaultMaxAttackDamage = 25f;
    private PlayerAbilities playerAbilities;
    private PlayerHealthSystem playerhealthSystem;
    public GameObject VFXHit;

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
        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
        target = new Vector3(targetPlayer.position.x, targetPlayer.position.y, targetPlayer.position.z);
        playerAbilities = GameObject.Find("BoneKnightIdle").GetComponent<PlayerAbilities>(); //Change name for future gameplay bro
        playerhealthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthSystem>();
        cameraShake = GameObject.Find("CameraHolder").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {

        if (targetPlayer != null) {
            BulletMove();
        }
      
    }


    private void BulletMove() {

        //Define the direction
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target) {
            Destroy(gameObject);
        }
    }

    public int RandomDefaultDamage()
    {
        // Randomize the default damage from the bullet
        randomDefaultDamage = Mathf.FloorToInt(Random.Range(defaultMinAttackDamage, defaultMaxAttackDamage));
        return randomDefaultDamage;
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player") {
            
            //Instantiate some vfx if the bullet hit an obstacle, then the bullet is destroy
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            GameObject GOVFX = Instantiate(VFXHit, pos, rot);
            Destroy(gameObject);
            Destroy(GOVFX, 1f);


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
            else {
                //is invincible
                damageText = damagePop.GetComponentInChildren<TextMeshPro>();
                damageText.text = "Dodge";
                Destroy(GODamagePop, 1f);
            }


            //then the bullet is destroy
            Destroy(gameObject);
        }


        if (other.transform.tag == "Booster")
        {
            //Instantiate some vfx if the bullet hit an obstacle, then the bullet is destroy
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            GameObject GOVFX = Instantiate(VFXHit, pos, rot);
            Destroy(gameObject);
            Destroy(GOVFX, 1f);
        }


    }
}
