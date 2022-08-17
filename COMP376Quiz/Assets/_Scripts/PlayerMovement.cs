//-------------------------------------------------------------------------------------------
//Quiz

//Written by: Ziming Wang 40041601

//For COMP 376 - Fall 2020
//-------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip collecting;
    private AudioSource audioPlayer;
    public AudioSource JumpSound;

    [SerializeField] private Animator _animator;
    [SerializeField] private Camera cam;
    [SerializeField] private CharacterController controller;
    [SerializeField, Min(0)] private float speed = 5f;
    [SerializeField, Min(0)] private float rotationSpeed = 10f;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField, Min(0)] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField, Min(0)] private float jumpHeight = 2f;

    private Vector3 movement;
    private Vector3 gravitationalForce;
    private bool isGrounded;
    private bool jumpMomentumCheck;

    private void Start (){
        _animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        audioPlayer = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        // check if mario is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, whatIsGround);

        // calculate movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 forward = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(cam.transform.right, Vector3.up).normalized;
        movement = right * horizontal + forward * vertical;

        // check if player is trying to move
        if (movement != Vector3.zero)
        {
            // look in the direction of the movement
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed * Time.deltaTime);

        }

        jumpMomentumCheck = jumpMomentumCheck && Input.GetButton("Jump") && !isGrounded;

        // simulate gravity
        if (isGrounded)
        {
            // mario is standing on ground
            gravitationalForce.y = gravity * Time.deltaTime;
            jumpMomentumCheck = true;
            _animator.SetBool("isJump", false);

            bool move = (vertical > 0) || (horizontal != 0);
            _animator.SetBool("isRun", move);
        }
        else
        {
            // mario is in the air
            if (!jumpMomentumCheck && gravitationalForce.y > 0)
                gravitationalForce.y = 0;
            else
                gravitationalForce.y += gravity * Time.deltaTime;
        }

        // jump
        if (Input.GetButton("Jump") && isGrounded){
            JumpSound.Play();
            _animator.SetBool("isJump", true);
            gravitationalForce.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
        }

        // move mario
        controller.Move((movement * speed * Time.deltaTime) + (gravitationalForce * Time.deltaTime));
    }

    void OnCollisionEnter(Collision coll){
        if(coll.gameObject.name == "Coin"){
            audioPlayer.PlayOneShot(collecting);
        }
    }
}
