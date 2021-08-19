using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public override void OnStartLocalPlayer()
    {
        /*Camera.main.transform.SetParent(transform);
        //Cursor.lockState = CursorLockMode.Locked;*/
        if(isLocalPlayer){
            Camera.main.GetComponent<CameraController>().enabled = true;
            Camera.main.GetComponent<CameraController>().player = transform;
        }else{
            Camera.main.GetComponent<CameraController>().enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            CharacterController controller = GetComponent<CharacterController>();
            // is the controller on the ground?
            if (controller.isGrounded)
            {
                //Feed moveDirection with input.
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                //Multiply it by speed.
                moveDirection *= speed;
                //Jumping
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;

            }
            //Applying gravity to the controller
            moveDirection.y -= gravity * Time.deltaTime;
            //Making the character move
            controller.Move(moveDirection * Time.deltaTime);
        }


    }
}
