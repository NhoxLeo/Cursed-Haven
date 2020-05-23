using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySphereProjectile : MonoBehaviour
{


    [Header("Scale properties")]
    Vector3 minScale;
    public Vector3 maxScale;
    public bool repeatable = true;
    public float speed = 2f;
    public float duration = 1f;


 




    IEnumerator Start() {
         minScale = transform.localScale;
        while (repeatable) {

            yield return RepeatLerp(minScale, maxScale, duration);
        
        }
    
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time) {

        float i = 0f;
        float rate = (1f / time) * speed;
        while (i < 1) {

            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        
        }
    
    }









}
