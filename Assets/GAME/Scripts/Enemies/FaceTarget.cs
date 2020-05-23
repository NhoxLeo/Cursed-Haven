using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{

    private Transform targetPlayer;
    private EnemyInformations enemyInformations;




    private void Start()
    {

       // if (PlayerInformations.isAlive == true){
            targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
            enemyInformations = GetComponent<EnemyInformations>();
       // }

    }

    // Start is called before the first frame update
    void Update()
    {
        if (targetPlayer != null) {
            FaceTargetPlayer();
        }
        
    }

    private void FaceTargetPlayer()
    {

        if (enemyInformations.currentEnemyHealth > 0) {

            //always face the target
            Vector3 direction = (targetPlayer.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

       
    }
}
