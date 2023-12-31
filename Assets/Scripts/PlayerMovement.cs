using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public bool disabled = false;

    public float speed = 12f;
    public float gravity = -100.05f;

    public float jumpHeight = 10.5f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool JumpPressed;

    void Update()
    {
        if (!disabled)
        {
            //Move
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            //reset the velocity.y because grows constantly to infinity from the lines below
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // 0f is good too but -2f work better;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime); //speed of movement in a period of time, you can move with only controller.Move(move)

            //gravity
            velocity.y += gravity * Time.deltaTime; //change the height constantly not to stay stuck at the same height, need to by more bigger to by more down, movement of gravity in a period of time
            controller.Move(velocity * Time.deltaTime); // add the gravity to the player

            //Jump
            //Check if the button was pressed because directly will not jump always
            if (Input.GetButtonDown("Jump"))
            {
                JumpPressed = true;
            }
            if (JumpPressed && isGrounded)
            {
                velocity.y += Mathf.Sqrt(jumpHeight * -1.0f * gravity);
                JumpPressed = false;
            }
        }
    }
}
