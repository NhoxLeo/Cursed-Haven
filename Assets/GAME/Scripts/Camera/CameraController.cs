using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    [Header("Camera Properties")]
    [SerializeField] private Camera cam;
    private Transform cameraTarget;
    public float yOffset = 5.5f;
    public float xOffset = 6f;

    private float offsetAbilityR = 4f;
    private float lerpIntensityAbilityR = 2f;

    private Vector3 currentPos;
    private Vector3 newPos;
    private float lerpIntensity = 5f;


    private PlayerAbilities playerAbilities;
    private CameraShake cameraShake;

    private float tempPowerCamShake = 0.01f;


    private void Start()
    {
        //if (PlayerInformations.isAlive == true) {
            cameraTarget = GameObject.FindGameObjectWithTag("Player").transform;
            cameraShake = GameObject.Find("CameraHolder").GetComponent<CameraShake>();
            playerAbilities = GameObject.Find("BoneKnightIdle").GetComponent<PlayerAbilities>();
      //  }
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraTarget != null) {
            currentPos = cam.transform.position;

            if (playerAbilities.isAbilityR == false || playerAbilities.zoomCam == false)
            {
                newPos = new Vector3(cameraTarget.position.x, cameraTarget.position.y + yOffset, cameraTarget.position.z - xOffset);
                cam.transform.position = Vector3.Lerp(currentPos, newPos, Time.deltaTime * lerpIntensity);

                //reset the camera shake power
                cameraShake.tempPower = cameraShake.power;

            }
            if (playerAbilities.isAbilityR == true && playerAbilities.zoomCam == true) {
                newPos = new Vector3(cameraTarget.position.x, cameraTarget.position.y + offsetAbilityR, cameraTarget.position.z - offsetAbilityR);
                cam.transform.position = Vector3.Lerp(currentPos, newPos, Time.deltaTime * lerpIntensityAbilityR);



                //decrease value of the camera shake power
                cameraShake.tempPower = tempPowerCamShake;
                cameraShake.triggerShake = true;

     
            }
        }
       
    }
}
