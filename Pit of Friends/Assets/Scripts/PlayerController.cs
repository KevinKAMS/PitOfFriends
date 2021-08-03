using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed =10.0f;
    public float jumpForce = 12.0f;
    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale =0.02f;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * movespeed, moveDirection.y, Input.GetAxis("Vertical") * movespeed);
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * movespeed;
        moveDirection.y = yStore;

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);


        controller.Move(moveDirection * Time.deltaTime);


    }
}
