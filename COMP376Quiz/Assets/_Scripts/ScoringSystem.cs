//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject healthPoint;
    public static int theScore;
    public static int hp;

    // Start is called before the first frame update
    void Update(){
        scoreText.GetComponent<Text>().text = "Score: " + theScore;
        healthPoint.GetComponent<Text>().text = "HP: " + (100 - hp);
    }
}
