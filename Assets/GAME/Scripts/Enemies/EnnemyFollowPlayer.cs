using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyFollowPlayer : MonoBehaviour
{

    [Header("NavMesh Agent proprieties")]
    private Transform targetPlayer;
    public bool targetIsAlive = true;
    private NavMeshAgent nma;
    public bool isAttacking = false;
    public bool hasToAttack = false; // will refer to an other script (depend of the enemy attack)



    [Space(5)]
    [Header("NavMesh Agent Sight")]
    [SerializeField] private float maxDistSight = 7f;
    public bool canSeeTheTarget = false;
    [SerializeField] private bool isRangeEnemy = false;
    [SerializeField] private float rayHeight = 0.5f;

    private EnemyInformations enemyInformations;
    public Animator anim;


    
    
    void Start()
    {
        //if (PlayerInformations.isAlive == true) {
            targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
            nma = GetComponent<NavMeshAgent>();
            enemyInformations = GetComponent<EnemyInformations>();
       // }

    }

    void Update()
    {

        if (targetPlayer != null) {

            if (isRangeEnemy == false)
            {
                EnemyState();
            }
            else {
                EnemySight();
            }
           
        }

       
    }


    private void EnemyState() {

        //Define the distance between the enemy and the target
        float distance = Vector3.Distance(transform.position, targetPlayer.position);


        if (enemyInformations.currentEnemyHealth > 0)
        {
            if (distance >= nma.stoppingDistance)  //Follow the target
            {
                nma.SetDestination(targetPlayer.transform.position);
                hasToAttack = false;

            }
            else if (isAttacking == false)
            {
                hasToAttack = true;
                
            }
            
        }
        else {


            nma.SetDestination(transform.position);
        }

      
                           
    }

    private void EnemySight() {

        float distance = Vector3.Distance(transform.position, targetPlayer.position);

        if (enemyInformations.currentEnemyHealth > 0)
        {

            if (distance >= nma.stoppingDistance || canSeeTheTarget == false)  //Follow the target
            {
                nma.SetDestination(targetPlayer.transform.position);
                anim.SetBool("isCloseEnough", false);
            }
            else if (isAttacking == false)
            {
                hasToAttack = true;
                anim.SetBool("isCloseEnough", true);
                Debug.Log("oh yeah");

            }

        }
        else {

            nma.SetDestination(transform.position);
        }


        RaycastHit hit;
        Debug.DrawRay(transform.position + Vector3.up * rayHeight, transform.forward * maxDistSight, Color.red);
        Debug.DrawRay(transform.position + Vector3.up * rayHeight, (transform.forward + transform.right).normalized * maxDistSight, Color.red);
        Debug.DrawRay(transform.position + Vector3.up * rayHeight, (transform.forward - transform.right).normalized * maxDistSight, Color.red);

        if (Physics.Raycast(transform.position + Vector3.up * rayHeight, transform.forward, out hit, maxDistSight)) {

            if (hit.collider.gameObject.tag == "Player")
            {
                canSeeTheTarget = true;
            }

            
        }

    }


/*
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, nma.stoppingDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, nma.radius);
    }


*/
}
