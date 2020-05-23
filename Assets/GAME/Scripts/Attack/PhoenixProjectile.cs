using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoenixProjectile : MonoBehaviour
{


    [Header("Projectile Attributes")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float lifeTime = 2f;


    public int randomDefaultDamage;
    public float defaultMinAttackDamage = 30f;
    public float defaultMaxAttackDamage = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile toward
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
}
