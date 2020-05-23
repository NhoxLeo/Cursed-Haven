using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOn : MonoBehaviour
{
    [SerializeField] private float speed = 60f; // 60f seems fine

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
