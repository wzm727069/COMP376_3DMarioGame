//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public AudioSource collectSound;
    public GameObject Prefab;

    void OnTriggerEnter(Collider other){
        //collectSound.Play();
        if(other.gameObject.tag == "Player" && gameObject.tag == "Coin"){
            collectSound.Play();
            ScoringSystem.theScore += 1;
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Player" && gameObject.tag == "RedCoin"){
            collectSound.Play();
            ScoringSystem.theScore += 3;
            Destroy(gameObject);
        }
        if(ScoringSystem.theScore >= 100){
            Instantiate(Prefab, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
