using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public List<GameObject> shields;
    [SerializeField] private float yPos = 1f;
    [SerializeField] private float speedLerp = 1f;
    [SerializeField] private float shieldDelay = .5f;
    [SerializeField] private float currentDelay = 0f;
    private int currentIndex;
    private CameraShake camerashake;


    // Start is called before the first frame update
    void Start()
    {

        camerashake = GameObject.Find("CameraHolder").GetComponent<CameraShake>();


        foreach (Transform child in transform) {

            if (child.tag == "VFX") {
                shields.Add(child.gameObject);       
            }      
        }

        for (int i = 0; i < shields.Count; i++)
        {
            currentDelay = currentDelay + shieldDelay;
            StartCoroutine("WaitForNextShield");
            
        }
    }


    IEnumerator WaitForNextShield() {

        yield return new WaitForSeconds(currentDelay);    

        lerpPosY(currentIndex);

    }


    private void lerpPosY( int indexShield)
    {
       // speedLerp = 0;
        currentIndex++;    
        shields[indexShield].transform.position = Vector3.Lerp(shields[indexShield].transform.position,  new Vector3(shields[indexShield].transform.position.x, yPos, shields[indexShield].transform.position.z), speedLerp);
        camerashake.triggerShake = true;

    }



}
