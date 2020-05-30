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
    
   
    [Space(5)]
    [Header("Area Spell Attack")]
    [SerializeField] private GameObject SpellRangeBullet;
    private Transform player;


    [Space(5)]
    [Header("General Attributes")]
    [SerializeField] private int randomIndexAttack;
    private HordeMode hordeMode;






    // Start is called before the first frame update
    void Start()
    {
        enemyStateAttack = gameObject.GetComponent<EnnemyFollowPlayer>();
        projectileParent = GameObject.Find("Projectiles").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hordeMode = GameObject.Find("GameMode").GetComponent<HordeMode>();


    }


    void Update()
    {
        randomIndexAttack = Mathf.FloorToInt(Random.Range(1,2));
        Debug.Log(randomIndexAttack);



        /* 
        if (enemyStateAttack.hasToAttack == true)
        {
            if (randomIndexAttack == 1) {
                StartCoroutine("RangeAttack");
            }

           if (randomIndexAttack == 2 && hordeMode.currentWave >= 1) {
                StartCoroutine("SpellRangeAreaAttack");
            }

         }*/
    }


    public IEnumerator RangeAttack()
    {

        enemyStateAttack.isAttacking = true;
        //Trigger melee Attack Animation
        //trigger VFX animation
        GameObject GOBullet = Instantiate(bullet, canonOrigin.position, Quaternion.identity, projectileParent);
        enemyStateAttack.hasToAttack = false;

        //Mike met ton son de enemy qui lance projectile;


        yield return new WaitForSeconds(waitingTimeAfterHit);
        enemyStateAttack.isAttacking = false;



    }

    IEnumerator SpellRangeAreaAttack() {
        
        enemyStateAttack.isAttacking = true;

        GameObject GOSpellCast = Instantiate(SpellRangeBullet, new Vector3(player.position.x, player.position.y + 0.5f, player.position.z) , Quaternion.identity, projectileParent);
      
       
        enemyStateAttack.hasToAttack = false;       
        yield return new WaitForSeconds(2f); 
        enemyStateAttack.isAttacking = false;

    }


}
