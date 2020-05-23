﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardCam : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
