//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobomb : MonoBehaviour
{
    public ParticleSystem explosion;

    private Transform player;
    private float distance;
    public float speed;
    public float howclose;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);

        if(distance <= howclose){
            transform.LookAt(player);
            GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player" && gameObject.tag == "Bobomb"){
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ScoringSystem.hp += 2;
        }
    }
}
