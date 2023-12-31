using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController4 : MonoBehaviour
{
    public float MoveSpeed = 50f;
    public float MaxSpeed = 15f;
    public float Drag = 0.98f;
    public float SteerAngle = 20f;
    public float Traction = 1f;

    private Vector3 MoveForce;

    // Update is called once per frame
    void Update()
    {
        //Moving
        MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        //Steering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        //Drag
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed);

        //Traction
        Debug.DrawRay(transform.position, MoveForce.normalized * 15f, Color.red);
        Debug.DrawRay(transform.position, transform.forward * 15f, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;

    }
}
