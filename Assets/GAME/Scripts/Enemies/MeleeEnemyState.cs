using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyState : MonoBehaviour
{
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
    [SerializeField] private int randomAttack;
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

        randomAttack = Mathf.FloorToInt(Random.Range(1, 3));


        if (enemyFollowPlayer.hasToAttack == true && randomAttack == 1)
        {
     
            enemyAnim.SetBool("Attack", true);
            
         
        }
        else {
            enemyAnim.SetBool("Attack", false);
        }

        if (enemyFollowPlayer.hasToAttack == true && randomAttack == 2) {
            StartCoroutine("EarthQuakeAttack");
        }


        if (enemyInformations.isDead == true) {
            StartCoroutine("DyingEffect");
            enemyInformations.isDead = false;

        }
    }


    IEnumerator EarthQuakeAttack() {

        enemyFollowPlayer.isAttacking = true;
        GameObject GOEarthQuake = Instantiate(earthQuakeprojectile, canonOrigin.position, canonOrigin.rotation, projectileParent);
        enemyFollowPlayer.hasToAttack = false;


        yield return new WaitForSeconds(2.5f);
        enemyFollowPlayer.isAttacking = false;

    }

    IEnumerator DyingEffect()
    {

        enemyAnim.SetTrigger("isDead");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }


    public void DyingDust() {

       Instantiate(VFXDustDying,dustOrigin.position, Quaternion.identity);
       Debug.Log("spawnDust");
    }

}
