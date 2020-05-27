using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyInformations : MonoBehaviour
{
    [Header("Health properties")]
   // [SerializeField] private TextMeshProUGUI healthText;
    public int MaxValue = 200;
    public int currentEnemyHealth;
    [SerializeField] private GameObject VFXDie;
    [SerializeField] private Canvas health;
    private HordeMode hordeMode;
    public bool isDead = false;

    private Camera cam;
    public HealthBar healthBar;
    private Collider m_collider;
    private FreezeTime freeTime;






    // Start is called before the first frame update
    void Start()
    {
       
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        hordeMode = GameObject.Find("GameMode").GetComponent<HordeMode>();
        m_collider = GetComponent<Collider>();
        freeTime = GameObject.Find("Freezer").GetComponent<FreezeTime>();

        MaxValue += 5 * hordeMode.currentWave;

        currentEnemyHealth = MaxValue;
        healthBar.SetMaxHealth(MaxValue);


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
            freeTime.StopFrame(0.1f);


            //Acces the horde mode script to decrease value of the current number of enemy

            //Instantitate some vfx dying effect, then destroy the whole enemy component


        }
    }



}


