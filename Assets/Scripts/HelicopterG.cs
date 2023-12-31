using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterG : MonoBehaviour
{
    public Vector3 MovementSpeed;
    public float rotSpeed, degressSpeed, gravity, fadeoutSpeed, cameraSpeed;
    public Transform camerapoint;
    //public Animator ani;

    bool ground, tfly, stopMove, fly;
    Vector3 forc, rot;

    Rigidbody rg;

    /*public void setFly()
    {
        ani.SetBool("start", false);
        ani.SetBool("fly", true);
    }*/

    // Start is called before the first frame update
    void Start()
    {
        rg = transform.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        ground = true;
        forc.y = 0f;
        rg.useGravity = true;
    }

    private void OnTriggerExit(Collider other)
    {
        ground = false;
    }

    void flying()
    {
        rot = Vector3.zero;
        //fly = ani.GetBool("fly");

        if (Input.GetKey(KeyCode.E))
        {
            tfly = true;
            rg.useGravity = false;
            //If(ground&&!fly)ani.SetBool("start",true);
            if (fly) forc.y = 1f * MovementSpeed.y;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            tfly = true;
            if (!ground) forc.y = -1f * MovementSpeed.y;
        }
        else
        {
            if (!ground) forc.y = -1f * gravity * Time.deltaTime;
            tfly = false;
        }

        /*if(!tfly)
         * {
         * if(fly&&ground)
         * {
         * ani.SetBool("start",false);
         * ani.GetBool("fly",false);
         * }
         * }*/

        if (fly)
        {
            if (Input.GetKey(KeyCode.W))
            {
                stopMove = false;
                forc.z = 1f * MovementSpeed.z;
                rot.x = 20f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                stopMove = false;
                forc.z = -1f * MovementSpeed.z;
                rot.x = -20f;
            }

            if (Input.GetKey(KeyCode.A))
            {
                stopMove = false;
                forc.x = -1f * MovementSpeed.x;
                rot.z = 15f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                stopMove = false;
                forc.x = 1f * MovementSpeed.x;
                rot.z = -15f;
            }

            if (!Input.anyKey) stopMove = true;
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rot), Time.deltaTime * degressSpeed);
            cameraMovement();
        }

        if (transform.localRotation != Quaternion.Euler(0f, 0f, 0f))
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rot), Time.deltaTime * degressSpeed);

        }
    }

    void cameraMovement()
    {
        float dy = Input.GetAxis("Mouse X");
        dy *= cameraSpeed * Time.deltaTime;
        camerapoint.Rotate(0f, dy, 0f);

        var tp = transform.parent;
        transform.parent.rotation = Quaternion.Lerp(tp.rotation, camerapoint.rotation, Time.deltaTime * rotSpeed);
        camerapoint.localRotation = Quaternion.Lerp(camerapoint.localRotation, Quaternion.Euler(Vector3.zero), Time.deltaTime);

    }
    // Update is called once per frame
    void Update()
    {
        flying();
    }
    private void FixedUpdate()
    {
        if (fly)
        {
            rg.velocity = Vector3.zero;

            if (stopMove) forc = Vector3.Slerp(forc, Vector3.zero, Time.fixedDeltaTime * fadeoutSpeed);

            rg.AddRelativeForce(forc * 10f);
        }
    }

}
