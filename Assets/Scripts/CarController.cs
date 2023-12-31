using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentsteerAngle;
    private float currentbreackForce;

    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breackForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;

    [SerializeField] Transform frontRightWheelTransform;
    [SerializeField] Transform frontLeftWheelTransform;
    /*[SerializeField] Transform backRightWheelTransform;
    [SerializeField] Transform backLeftWheelTransform;
    */

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreackForce = isBreaking ? breackForce : 0f;
        if(isBreaking)
        {
            ApplyBreaking();
        }
    }
    void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreackForce;
        frontLeftWheelCollider.brakeTorque = currentbreackForce;
        backRightWheelCollider.brakeTorque = currentbreackForce;
        backLeftWheelCollider.brakeTorque = currentbreackForce;
    }
    void HandleSteering()
    {
        currentsteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentsteerAngle;
        frontRightWheelCollider.steerAngle = currentsteerAngle;
    }
    void UpdateWheels()
    {
        frontRightWheelTransform.transform.localRotation = Quaternion.Euler(0f, currentsteerAngle, -90f);
        frontLeftWheelTransform.transform.localRotation = Quaternion.Euler(0f, currentsteerAngle, -90f);
    }
    /*
    void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    */
    // Update is called once per frame
    void Update()
    {

    }
}
