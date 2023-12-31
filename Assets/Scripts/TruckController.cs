using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    [SerializeField] private WheelCollider fRWC;
    [SerializeField] private WheelCollider fLWC;
    [SerializeField] private WheelCollider mFRWC;
    [SerializeField] private WheelCollider mFLWC;
    [SerializeField] private WheelCollider mBRWC;
    [SerializeField] private WheelCollider mBLWC;
    [SerializeField] private WheelCollider bRWC;
    [SerializeField] private WheelCollider bLWC;
    [SerializeField] Transform fRWT;
    [SerializeField] Transform fLWT;
    [SerializeField] Transform mFRWT;
    [SerializeField] Transform mFLWT;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

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
        mFRWC.motorTorque = currentAcceleration;
        mFLWC.motorTorque = currentAcceleration;

        fRWC.brakeTorque = currentBreakForce;
        fLWC.brakeTorque = currentBreakForce;
        mFRWC.brakeTorque = currentBreakForce;
        mFLWC.brakeTorque = currentBreakForce;
        mBRWC.brakeTorque = currentBreakForce;
        mBLWC.brakeTorque = currentBreakForce;
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

        fLWC.steerAngle = currentTurnAngle;
        fRWC.steerAngle = currentTurnAngle;
        mFRWC.steerAngle = currentTurnAngle;
        mFLWC.steerAngle = currentTurnAngle;

        fRWT.transform.localRotation = Quaternion.Euler(0f, currentTurnAngle, -90f);
        fLWT.transform.localRotation = Quaternion.Euler(0f, currentTurnAngle, -90f);
        mFRWT.transform.localRotation = Quaternion.Euler(0f, currentTurnAngle, -90f);
        mFLWT.transform.localRotation = Quaternion.Euler(0f, currentTurnAngle, -90f);
    }
}