using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    //public Transform playerBody;

    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;
    float zRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation -= mouseX;

        zRotation = Mathf.Clamp(-30f, yRotation, 30f);

        transform.localRotation = Quaternion.Euler(xRotation, -yRotation, zRotation);

        //playerBody.localRotation = Quaternion.Euler(90f,0f,yRotation);
        //playerBody.Rotate(Vector3.back * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }
}