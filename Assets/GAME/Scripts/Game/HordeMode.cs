using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HordeMode : MonoBehaviour
{


    [Header("Timer settings")]
    [SerializeField] private TextMeshProUGUI TimerWaveInterval;
    [SerializeField] private TextMeshProUGUI WaveCounter;
    [SerializeField] private float gameTimer = 0f;
    [SerializeField] private bool isGameOver = false;
    [SerializeField] private bool isPlaying = false;

    [Space(5)]
    [Header("Wave settings")]
    public int currentWave = 0;
    [SerializeField] private float intervalWaveTime = 10f;
    [SerializeField] private int bossWaveInterval = 5;
    [SerializeField] private TextMeshProUGUI WaveCounterUI;
    [SerializeField] private GameObject WaveCounterContainer;
    private float intervalWaveTimeStatic = 3f;
    private bool bossWave = false;

    [Space(5)]
    [Header("Enemies settings")]
    [SerializeField] private int nbrEnemies = 4;
    [SerializeField] private int nbrEnemiesAdded = 2;
    [SerializeField] private TextMeshProUGUI nbrEnemyRemainingText;
    [SerializeField] private TextMeshProUGUI nbrWaveText;
    public int currentNbrEnemy;
    [SerializeField] private Transform EnemiesContainer;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] enemySpawn;
    public int killTotal = 0;





    private void Start()
    {
        currentNbrEnemy = nbrEnemies + (nbrEnemiesAdded * currentWave);
        StartCoroutine("IntervalWaveTimerStart");
        StartCoroutine("GameTimerStart");
        WaveCounterContainer.SetActive(false);




    }

    void Update()
    {
        //Assign each text valuee
        //TimerWaveInterval.text = "NEXT WAVE : " + intervalWaveTime.ToString();
       // WaveCounter.text = "WAVE : " + currentWave.ToString();
        nbrEnemyRemainingText.text = currentNbrEnemy.ToString();
        nbrWaveText.text = currentWave.ToString();
        WaveCounterUI.text = "WAVE " + currentWave.ToString();


        if (currentNbrEnemy <= 0 && isPlaying == true) {
            isPlaying = false;
            intervalWaveTime = intervalWaveTimeStatic;
            StartCoroutine("IntervalWaveTimerStart");

        }


        //Boss at each 5 round
        if ((currentWave % bossWaveInterval == 0) && (currentWave != 0))
        {
            bossWave = true;
        }
        else {
            bossWave = false;
        }

      

    }

    IEnumerator IntervalWaveTimerStart() {

        while (intervalWaveTime > 0)
        {
            //Decrease timer value for the interval pause between each wave
            if (isPlaying == false) {
                yield return new WaitForSeconds(1f);
                intervalWaveTime--;
            }

            //Increase wave value (next wave)
            if (intervalWaveTime == 0)
            {
                currentWave++;
                WaveCounterContainer.SetActive(true);
                isPlaying = true;
                currentNbrEnemy = nbrEnemies + (nbrEnemiesAdded * currentWave);
                StartCoroutine("StartWave");

            }
        }
    }

    IEnumerator GameTimerStart() {

        //Increase the timer value while the player is not dead
        while (isGameOver == false) {
            yield return new WaitForSeconds(1f);
            gameTimer++;
        }

    }

    private float RandomDelayEnemySpawn(float minSpawnDelay, float maxSpawnDelay) {

        float randomEnemySpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        return randomEnemySpawnDelay;
    }


    private int RandomEnemyPicking() {

        int randomEnemy = Random.Range(0, enemies.Length);
        return randomEnemy;

    }

    private Vector3 RandomSpawnEnemy() {

        int randomPos = Random.Range(0, enemySpawn.Length);
        return enemySpawn[randomPos].position;
    }





   IEnumerator StartWave()
    {
        //Change the value of the number of enemy for the next wave
        nbrEnemies = currentNbrEnemy;
       
        if (isPlaying == true) {

            //Instantiate new enemy for the new wave and increase the enemy number at each new wave
            for (int i = 0; i < nbrEnemies; i++)
            {
                yield return new WaitForSeconds(RandomDelayEnemySpawn(1f, 3f));
                GameObject GOEnemy = Instantiate(enemies[RandomEnemyPicking()], RandomSpawnEnemy(), Quaternion.identity, EnemiesContainer);
            }
        }

    }


}
