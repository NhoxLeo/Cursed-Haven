using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexDissolve : MonoBehaviour
{

    [SerializeField] private Material dissolveMat;
    private float alphaTresholdDissolve = 1f;
    private float currentDissolveAmout = 1f;
    private float speedDissolve = 1f;
    private PlayerAbilities playerAbilities;


    // Start is called before the first frame update
    void Start()
    {
        dissolveMat.SetFloat("Vector1_C02037ED", alphaTresholdDissolve);
        playerAbilities = GameObject.Find("BoneKnightIdle").GetComponent<PlayerAbilities>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDissolveAmout >= .2f && playerAbilities.isInvicible == true) {

            dissolveMat.SetFloat("Vector1_C02037ED", currentDissolveAmout -= (Time.deltaTime * speedDissolve));
        }

        if (playerAbilities.isInvicible == false) {

            dissolveMat.SetFloat("Vector1_C02037ED", currentDissolveAmout += (Time.deltaTime * speedDissolve));
        }
    }
}
