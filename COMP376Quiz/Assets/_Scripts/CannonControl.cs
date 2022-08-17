//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{
    public Rigidbody cannon;
    public Transform barrelEnd;
    private float nextActionTime = 0.0f;
    public float period = 8.0f;

    void Start(){
        //Destroy(gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1")){
        if(Time.time > nextActionTime){
            nextActionTime += period;
            Rigidbody cannonInstance;
            cannonInstance = Instantiate(cannon, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
            cannonInstance.AddForce(barrelEnd.up * Random.Range( 500f, 1200f));
        }
    }
}
