using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{

    [Header("Range proprieties")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform canonOrigin;
    [SerializeField] private float waitingTimeAfterHit = 1f;
    private Transform projectileParent;
    public EnnemyFollowPlayer enemyStateAttack;

    // Start is called before the first frame update
    void Start()
    {
        enemyStateAttack = gameObject.GetComponent<EnnemyFollowPlayer>();
        projectileParent = GameObject.Find("Projectiles").transform;
    }


    void Update()
    {
        if (enemyStateAttack.hasToAttack == true)
        {
            StartCoroutine("RangeAttack");
        }
    }


    IEnumerator RangeAttack()
    {

        enemyStateAttack.isAttacking = true;
        //Trigger melee Attack Animation
        //trigger VFX animation
        GameObject GOBullet = Instantiate(bullet, canonOrigin.position, Quaternion.identity, projectileParent);
        enemyStateAttack.hasToAttack = false;


        yield return new WaitForSeconds(waitingTimeAfterHit);
        enemyStateAttack.isAttacking = false;



    }
}
