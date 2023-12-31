using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MotorcycleController : MonoBehaviour
{
    [SerializeField] private WheelCollider fRWC;
    [SerializeField] private WheelCollider fLWC;
    [SerializeField] private WheelCollider bRWC;
    [SerializeField] private WheelCollider bLWC;
    [SerializeField] Transform fWT;
    //[SerializeField] Transform bWT;

    public float acceleration = 1000f;
    public float breakingForce = 1000f;
    public float maxTurnAngle = 50f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    // Update is called once per frame
    void Update()
    {
        //Get forward/reverse acceleration from the vertical axis (W and S keys)
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        //If we are pressing space, give currentBreakingForce a value
        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;

        //Apply acceleration to front wheels
        fRWC.motorTorque = currentAcceleration;
        fLWC.motorTorque = currentAcceleration;

        fRWC.brakeTorque = currentBreakForce;
        fLWC.brakeTorque = currentBreakForce;
        bRWC.brakeTorque = currentBreakForce;
        bLWC.brakeTorque = currentBreakForce;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            currentTurnAngle = maxTurnAngle * -1.0f * Input.GetAxis("Horizontal");
        }

        fRWC.steerAngle = currentTurnAngle;
        fLWC.steerAngle = currentTurnAngle;
        //bRWC.steerAngle = currentTurnAngle;
        //bLWC.steerAngle = currentTurnAngle;
        fWT.transform.localRotation = Quaternion.Euler(0f, currentTurnAngle, -90f);
        //bWT.transform.localRotation = Quaternion.Euler(0f, currentTurnAngle, 0f);
    }
}

