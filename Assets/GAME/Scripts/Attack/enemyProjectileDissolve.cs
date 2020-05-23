using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectileDissolve : MonoBehaviour
{



    [Header("Dissolve properties")]
    public Material enemyProjectileMat;
    [SerializeField] private float speedDissolve = .5f;
    [SerializeField] private float maxDissolveAmount = .6f;
    [SerializeField] private float currentDissolveAmount = .12f;

    // Start is called before the first frame update
    void Start()
    {
        //Get the dissolve varibale from shader
        enemyProjectileMat.SetFloat("Vector1_BD060F8E", currentDissolveAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDissolveAmount <= maxDissolveAmount)
        {
            enemyProjectileMat.SetFloat("Vector1_BD060F8E", currentDissolveAmount += (Time.deltaTime * speedDissolve));
        }
    }
}
