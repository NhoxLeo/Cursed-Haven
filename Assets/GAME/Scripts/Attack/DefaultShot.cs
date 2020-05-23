using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefaultShot : MonoBehaviour
{
    [Header("Default Attack")]
    public Transform DefaultAttackOrigin;
    public GameObject defaultAttackGO;
    public float defaultAttackDelay = 0.1f;
    public float DefaultAttackIntensity = 20f;
    private bool isDefaultAttacking = false;
    private GameObject projectileParent;
    private Animator playerAnim;
    public GameObject preShot;

    void Start()
    {
        projectileParent = GameObject.Find("Projectiles");
        playerAnim = gameObject.GetComponent<Animator>();
        
    }

    void Update()
    {
        DefaultAttack();

    }

    private void DefaultAttack() {

        // Trigger the default attack
        if (Input.GetMouseButtonDown(0) && isDefaultAttacking == false)
        {
       
            playerAnim.SetTrigger("IsBasicAttack");
            isDefaultAttacking = true;
            StartCoroutine("DisableElement");
            StartCoroutine("DelayAttack");
        }
    }

    public void TriggerBasicProjectile() {
        preShot.SetActive(true);
        GameObject currentdefaultAttackGO = Instantiate(defaultAttackGO, DefaultAttackOrigin.position, DefaultAttackOrigin.rotation);
        currentdefaultAttackGO.transform.SetParent(projectileParent.transform);
      


    }

    IEnumerator DisableElement() {

        yield return new WaitForSeconds(0.5f);
        preShot.SetActive(false);
    }






    IEnumerator DelayAttack() {

        //Control the delay between each shot and decrease the number of ammo
        yield return new WaitForSeconds(defaultAttackDelay);
        isDefaultAttacking = false;
    }
}
