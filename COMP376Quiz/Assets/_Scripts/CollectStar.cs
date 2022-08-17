//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStar : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        
        if(gameObject.tag == "Star"){
            ScoringSystem.theScore = 0;
        }
        Destroy(gameObject);
    }
}

