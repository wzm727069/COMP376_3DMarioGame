//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform target = null;
    public Transform target2 = null;
    public Transform target3 = null;
    public Transform target4 = null;

    bool bJump = false;
    bool bJump2 = false;
    bool bJump3 = false;
    bool bJump4 = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Teleport" && bJump==false && bJump2==false )
        {
            this.transform.position = target.position;
            bJump = true;
        }

        if (other.gameObject.tag == "Teleport2" && bJump==false && bJump2==false )
        {
            this.transform.position = target2.position;
            bJump2 = true;
        }

        if(other.gameObject.tag=="Teleport3" && bJump3==false && bJump4==false )
        {
            this.transform.position = target3.position;
            bJump3 = true;
        }

        if (other.gameObject.tag == "Teleport4" && bJump3==false && bJump4==false )
        {
            this.transform.position = target4.position;
            bJump4 = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Teleport")
        {
            bJump2 = false;
        }
        if (other.gameObject.tag == "Teleport2")
        {
            bJump = false;
        }
        if (other.gameObject.tag == "Teleport3")
        {
            bJump4 = false;
        }
        if (other.gameObject.tag == "Teleport4")
        {
            bJump3 = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
