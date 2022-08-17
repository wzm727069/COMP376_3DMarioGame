//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{
    public GameObject bridge;
    public Transform endpoint;
    public float speed;

    void OnTriggerStay(Collider mario){
        mario.transform.position = Vector3.MoveTowards(mario.transform.position, endpoint.position, speed * Time.deltaTime);
    }
}
