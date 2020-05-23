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

 
    


    // Start is called before the first frame update
    void Start()
    {
        enemyFollowPlayer = gameObject.GetComponent<EnnemyFollowPlayer>();
        enemyInformations = GetComponent<EnemyInformations>();


    }

    // Update is called once per frame
    void Update()
    {
        if (enemyFollowPlayer.hasToAttack == true)
        {
     
            enemyAnim.SetBool("Attack", true);
         
        }
        else {
            enemyAnim.SetBool("Attack", false);
        }


        if (enemyInformations.isDead == true) {
            StartCoroutine("DyingEffect");
            enemyInformations.isDead = false;

        }
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
