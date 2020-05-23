using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float power = 0.1f;
    public float tempPower;
    public float duration = 0.3f;
    private Transform cameraHolder;
    public float slowDown;
    public bool triggerShake = false;
    private Vector3 startPos;
    private float initialDuration;



    // Start is called before the first frame update
    void Start()
    {
        cameraHolder = GameObject.Find("CameraHolder").transform;
        startPos = cameraHolder.localPosition;
        initialDuration = duration;
        tempPower = power;
    }

    // Update is called once per frame
    void Update()
    {

        if (triggerShake == true) {

            if (duration > 0)
            {

                cameraHolder.localPosition = startPos + Random.insideUnitSphere * tempPower;
                duration -= Time.deltaTime * slowDown;
            }
            else {

                triggerShake = false;
                duration = initialDuration;
                cameraHolder.localPosition = startPos;
            }
        }
        
    }


}
