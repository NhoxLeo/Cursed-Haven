using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityHit : MonoBehaviour
{

    [Header("Damage dealer")]
    public int randomDefaultDamage;
    public float defaultMinAttackDamage = 35f;
    public float defaultMaxAttackDamage = 55f;

    [Space(5)]
    [Header("Damage dealer poppop")]
    [SerializeField] private GameObject damagePop;
    [SerializeField] private float offestY;
    [SerializeField] private float minAngle = -10f;
    [SerializeField] private float maxAngle = 10f;
    private TextMeshPro damageText;



    private void Start()
    {
        Destroy(transform.parent.gameObject, 2.5f);
    }

    public int RandomDefaultDamage()
    {
        // Randomize the default damage from the bullet
        randomDefaultDamage = Mathf.FloorToInt(Random.Range(defaultMinAttackDamage, defaultMaxAttackDamage));
        return randomDefaultDamage;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy") {

            Debug.Log("lol");

            //Do some damage to the enemy
            other.gameObject.GetComponent<EnemyInformations>().HurtEnemy(RandomDefaultDamage());

            //instantiate the damage popop     
            damageText = damagePop.GetComponentInChildren<TextMeshPro>();
            damageText.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(minAngle, maxAngle)));
            damageText.text = RandomDefaultDamage().ToString();
            GameObject GODamagePop = Instantiate(damagePop, new Vector3(other.transform.position.x, other.transform.position.y + offestY, other.transform.position.z), Quaternion.identity);

           
            Destroy(GODamagePop, 1f);

        }
    }
}
