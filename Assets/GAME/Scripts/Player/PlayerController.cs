using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
  

    //private CharacterController characterController;
    private float horizontal;
    private float vertical;
    private Rigidbody rb;
    private bool isMoving = false;
    private Vector3 oldPos;

    [Header("Move propriety")]
    [SerializeField] private float moveSpeed = 5f;
    public Transform cam;
    Vector3 camForward;
    Vector3 move;
    Vector3 moveInput;
    float forwardAmount;
    float turnAmount;

 

    public Animator animCharacter;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();   
        oldPos = transform.position;


       

    }

    void Update()
    {

        //Movement Input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(horizontal * Time.deltaTime * moveSpeed, 0, vertical * Time.deltaTime * moveSpeed);


        camForward = Vector3.Scale(cam.up, new Vector3(1, 0, 1)).normalized;
        move = vertical * camForward + horizontal * cam.right;

        if (move.magnitude > 1) {

            move.Normalize();
        }

        Move(move);
        DetectPosition();
        
        
    }



    void Move(Vector3 move) {

        if (move.magnitude > 1) {
            move.Normalize();
        }

        this.moveInput = move;
        ConvertMoveInput();
        UpdateAnimator();
    }

    void ConvertMoveInput() {

        Vector3 localMove = transform.InverseTransformDirection(moveInput);
        turnAmount = localMove.x;
        forwardAmount = localMove.z;
    }



    void UpdateAnimator() {

        animCharacter.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        animCharacter.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }





    private void DetectPosition() {

        //Detect if the element is moving or not
        if (oldPos != transform.position)
        {
            isMoving = true;
            
        }
        else
        {

            //runningFx.Play();
            isMoving = false;
           
        }
        //The element has stopped moving
        oldPos = transform.position;
    }


  

}

