using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoosterManager : MonoBehaviour
{

    public List<Transform> BoosterSpawns;
    public float delaySpawnBooster = 60f;
    public float startingDelaySpawnBooster = 10f;
    private bool isBoosterActive = false;
    public bool alreadyHaveBooster = true; // waiting until false to begin the game
    public GameObject[] Boosters;

    // Start is called before the first frame update
    void Start()
    {
        

        //get all the possible spawn position
        foreach (Transform child in transform) {

            if (child.transform.tag == "Booster") {

                BoosterSpawns.Add(child);
            
            }
        }


        StartCoroutine("StartTimerBooster");


    }


    private void Update()
    {
        if (isBoosterActive == false && alreadyHaveBooster == false)
        {
            StartCoroutine("SpawnBooster");
        }

       

    }





    private int RandomBoosterPosPicking() {

        int RandomPos = Random.Range(1, BoosterSpawns.Count);

        return RandomPos;
    
    }

    private int RandomBoosterIndex() {

        int RandomBooster = Random.Range(0, Boosters.Length);

        return RandomBooster;

    }


    IEnumerator StartTimerBooster()
    {

        yield return new WaitForSeconds(startingDelaySpawnBooster);
        
   
        alreadyHaveBooster = false;
    }



    IEnumerator SpawnBooster() {

        isBoosterActive = true;
        alreadyHaveBooster = true;
        yield return new WaitForSeconds(delaySpawnBooster);
        GameObject BoosterGO = Instantiate(Boosters[RandomBoosterIndex()], BoosterSpawns[RandomBoosterPosPicking()].position, Quaternion.identity);

       
        isBoosterActive = false;
    }


}
