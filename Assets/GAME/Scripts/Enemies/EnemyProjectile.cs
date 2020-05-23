using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [Header("Projectile attributes")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private GameObject VFXHit;

    public int randomDefaultDamage;
    public float defaultMinAttackDamage = 10f;
    public float defaultMaxAttackDamage = 15f;


    /*
    [Space(5)]
    [Header("Damage dealer poppop")]
    [SerializeField] private GameObject damagePop;
    [SerializeField] private float offestY;
    [SerializeField] private float minAngle = -10f;
    [SerializeField] private float maxAngle = 10f;
    private TextMeshPro damageText;

    */


    // Start is called before the first frame update
    void Start()
    {
        //Move the bullet toward
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        Destroy(gameObject, lifeTime);
    }


    public int RandomDefaultDamage()
    {
        // Randomize the default damage from the bullet
        randomDefaultDamage = Mathf.FloorToInt(Random.Range(defaultMinAttackDamage, defaultMaxAttackDamage));
        return randomDefaultDamage;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Environment")
        {
            //Instantiate some vfx if the bullet hit an obstacle, then the bullet is destroy
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            // GameObject GOVFX = Instantiate(VFXHit, pos, rot);
            Destroy(gameObject);
        }


        if (other.transform.tag == "Player")
        {

            //Define the exact moment when the bullet hit the enemy (normal, pos)
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            //Do some damage to the player
          //  other.gameObject.GetComponent<EnemyInformations>().HurtEnemy(RandomDefaultDamage());

            //instantiate some vfx
            //  GameObject GOVFX = Instantiate(VFXHit, pos, rot);

            //instantiate the damage popop     
           /* damageText = damagePop.GetComponentInChildren<TextMeshPro>();
            damageText.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(minAngle, maxAngle)));
            damageText.text = RandomDefaultDamage().ToString();
            GameObject GODamagePop = Instantiate(damagePop, new Vector3(other.transform.position.x, other.transform.position.y + offestY, other.transform.position.z), Quaternion.identity);

            //then the bullet is destroy
            Destroy(gameObject);
            Destroy(GODamagePop, 1f);

    */
        }






    }


}
