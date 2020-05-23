using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyInformations : MonoBehaviour
{
    [Header("Health properties")]
   // [SerializeField] private TextMeshProUGUI healthText;
    public int MaxValue = 100;
    public int currentEnemyHealth;
    [SerializeField] private GameObject VFXDie;
    [SerializeField] private Canvas health;
    private HordeMode hordeMode;
    public bool isDead = false;

    private Camera cam;
    public HealthBar healthBar;


    private Collider m_collider;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyHealth = MaxValue;
        healthBar.SetMaxHealth(MaxValue);
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        hordeMode = GameObject.Find("GameMode").GetComponent<HordeMode>();
        m_collider = GetComponent<Collider>();


    }

    // Update is called once per frame
    void Update()
    {
        //healthText.text = currentEnemyHealth.ToString();
        /*
        if (isDead == true) {
            hordeMode.currentNbrEnemy--;
            hordeMode.killTotal += 1;
            Destroy(gameObject);
        }*/

      
    }


    public void HurtEnemy(int damageToGive) {


        if (currentEnemyHealth > 0) {

            currentEnemyHealth -= damageToGive;
            healthBar.SetHealth(currentEnemyHealth);

        }
       

        if (currentEnemyHealth <= 0) {
            isDead = true;
            m_collider.enabled = false;
            hordeMode.currentNbrEnemy--;
            hordeMode.killTotal += 1;


            //Acces the horde mode script to decrease value of the current number of enemy

            //Instantitate some vfx dying effect, then destroy the whole enemy component


        }
    }



}


