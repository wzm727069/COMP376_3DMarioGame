﻿//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow2 : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;

    public Transform camTransform;

    private Camera cam;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = transform;
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0,0,-distance);
        Quaternion rotation = Quaternion.Euler(currentX,currentY,0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
