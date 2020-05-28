using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterDynamic : MonoBehaviour
{


    private CameraShake cameraShake;



    // Start is called before the first frame update
    void Start()
    {
        cameraShake = GameObject.Find("CameraHolder").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Environment") {
            cameraShake.triggerShake = true;
            //Mike tu peux mettre ton son ici;

        }
    }
}