using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDissolve : MonoBehaviour
{

    [SerializeField] private Material dissolveMat;
    private float maxDissolveAmount = 1f;
    private float currentDissolveAmout = 1f;
    private float speedDissolve = 1f;
    private PlayerAbilities playerAbilities;
   



    

    // Start is called before the first frame update
    void Start()
    {
        dissolveMat.SetFloat("Vector1_8E88E5A4", maxDissolveAmount);
        playerAbilities = GameObject.Find("BoneKnightIdle").GetComponent<PlayerAbilities>();

    }


    private void Update()
    {
        if (currentDissolveAmout >= 0 && playerAbilities.isInvicible == true) {
            dissolveMat.SetFloat("Vector1_8E88E5A4", currentDissolveAmout -= (Time.deltaTime * speedDissolve));
        }

        if (playerAbilities.isInvicible == false) {       
            dissolveMat.SetFloat("Vector1_8E88E5A4", currentDissolveAmout += (Time.deltaTime * speedDissolve));
                     

        }

        
    }


}
