using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    Rigidbody rb;

    public float upForce;
    private float forwardSpeed=15f;

    private float tiltAmountForward;
    private float tiltVelocityForward;

    private float wantedYRotation;
    private float currentYRotation;
    private float rotateAmountByKeys = 2.5f;
    private float rotationYVelocity;

    private Vector3 velocityToSmoothDampToZero;

    private float sideMovementAmount = 30.0f;
    private float tiltAmountSideways;
    private float tiltAmountVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementUpDown();
        MovementForward();
        Rotation();
        ClampingSpeedValues();
        Swerve();

        rb.AddRelativeForce(Vector3.up * upForce);
        rb.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways));
    }

    void MovementUpDown()
    {
        if (Input.GetKey(KeyCode.LeftShift)) upForce = 30f;
        else if (Input.GetKey(KeyCode.LeftControl)) upForce = -20f;
        else if (!Input.GetKey(KeyCode.LeftShift)&&!Input.GetKey(KeyCode.LeftControl)) upForce = 10.1f;
    }

    void MovementForward()
    {
        if(Input.GetAxis("Vertical")!=0f)
        {
            rb.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * forwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20f * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);

        }
    }

    void Rotation()
    {
        if (Input.GetKey(KeyCode.Q)) wantedYRotation -= rotateAmountByKeys;
        if (Input.GetKey(KeyCode.E)) wantedYRotation += rotateAmountByKeys;

        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
    }

    void ClampingSpeedValues()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f) 
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, Mathf.Lerp(rb.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, Mathf.Lerp(rb.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, Mathf.Lerp(rb.velocity.magnitude, 5.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
        }
    }

    void Swerve()
    {
        if(Mathf.Abs(Input.GetAxis("Horizontal"))>0.2f)
        {
            rb.AddRelativeForce(Vector3.right * Input.GetAxis("Horizontal") * sideMovementAmount);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -20f * Input.GetAxis("Horizontal"), ref tiltAmountVelocity, 0.1f);
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0f, ref tiltAmountVelocity, 0.1f);
        }
    }
}
