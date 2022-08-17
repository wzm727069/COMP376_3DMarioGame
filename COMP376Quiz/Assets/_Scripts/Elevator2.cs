//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator2 : MonoBehaviour
{
    public GameObject platform;

    private void OnTriggerStay(){
        platform.transform.position += platform.transform.up * Time.deltaTime;
    }
}
