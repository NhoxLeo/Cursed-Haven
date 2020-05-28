using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyState : MonoBehaviour
{

    
    public enum MeleeType { Punch, EartQuake };
    public MeleeType meleeType;


    [Header("Animator properties")]
    [SerializeField] private Animator enemyAnim;
    private EnnemyFollowPlayer enemyFollowPlayer;
    private EnemyInformations enemyInformations;
    public GameObject VFXDustDying;
    public Transform dustOrigin;


    [Space(5)]
    [Header("EarthQuake properties")]
    public GameObject earthQuakeprojectile;
    [SerializeField] private Transform canonOrigin;
    private Transform projectileParent;

   






    // Start is called before the first frame update
    void Start()
    {
        
        enemyFollowPlayer = gameObject.GetComponent<EnnemyFollowPlayer>();
        enemyInformations = GetComponent<EnemyInformations>();
        projectileParent = GameObject.Find("Projectiles").transform;
  


    }

    // Update is called once per frame
    void Update()
    {

       

            if (enemyFollowPlayer.hasToAttack == true)
            {
                enemyAnim.SetBool("Attack", true);


            }
            else
            {
                enemyAnim.SetBool("Attack", false);
            }
        
    
        
       

   


        if (enemyInformations.isDead == true) {
            StartCoroutine("DyingEffect");
            enemyInformations.isDead = false;

        }
    }


    public IEnumerator EarthQuakeAttack() {

        //Mike met ton son de meleeEnemy qui attack au sol

        enemyFollowPlayer.isAttacking = true;
        GameObject GOEarthQuake = Instantiate(earthQuakeprojectile, canonOrigin.position, canonOrigin.rotation, projectileParent);
        enemyFollowPlayer.hasToAttack = false;


        yield return new WaitForSeconds(.5f);
        enemyFollowPlayer.isAttacking = false;

    }

    IEnumerator DyingEffect()
    {

        //Mike met ton son melee Enemy die

        enemyAnim.SetTrigger("isDead");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }


    public void DyingDust() {


        //Mike met ton son melee Enemy touch the floor while dying

        Instantiate(VFXDustDying,dustOrigin.position, Quaternion.identity);
       Debug.Log("spawnDust");
    }

}
