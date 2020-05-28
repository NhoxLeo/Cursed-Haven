using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemyState : MonoBehaviour
{
    [Header("Animator properties")]
    [SerializeField] private Animator enemyAnim;
    private EnnemyFollowPlayer enemyFollowPlayer;
    private EnemyInformations enemyInformations;


    // Start is called before the first frame update
    void Start()
    {
        enemyFollowPlayer = gameObject.GetComponent<EnnemyFollowPlayer>();
        enemyInformations = GetComponent<EnemyInformations>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyInformations.isDead == true)
        {
            StartCoroutine("DyingEffect");
            enemyInformations.isDead = false;

        }
    }


    IEnumerator DyingEffect()
    {

        //Mike met ton son melee Enemy die

        enemyAnim.SetTrigger("isDying");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);

    }
}
