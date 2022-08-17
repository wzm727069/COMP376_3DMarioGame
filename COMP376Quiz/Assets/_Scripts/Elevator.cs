//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    //public GameObject elevatorPanel;

    enum EleStates{goUP, goDown, PauseState};
    EleStates states;

    public Transform top;
    public Transform bottom;

    public float smooth;

    Vector3 newPos;
    
    bool hasRider;

    // Start is called before the first frame update
    void Start()
    {
        //elevatorPanel.SetActive(false);
        states = EleStates.PauseState;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasRider){
            states = EleStates.goUP;
        }
        else {
            states = EleStates.goDown;
        }

        FMS();
    }

    void onTriggerEnter(Collider coll){
        if(coll.tag == "Player"){
            //elevatorPanel.SetActive(true);
            coll.transform.parent = gameObject.transform;
            hasRider = true;
        }

    }

    void OnTriggerExit(Collider coll){
        if(coll.tag == "Player"){
            //elevatorPanel.SetActive(false);
            coll.transform.parent = null;
            hasRider = false;
        }
    }

    void FMS(){
        if(states == EleStates.goDown){
            newPos = bottom.position;
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }

        if(states == EleStates.goUP){
            newPos = top.position;
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }

        if(states == EleStates.PauseState){

        }
    }
}
