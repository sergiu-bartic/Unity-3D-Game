using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableAxe : MonoBehaviour
{
    public Rigidbody axe;
    public float throwForce = 50f;
    public Transform target,curve_point;
    private Vector3 old_pos;
    private bool isReturning = false;
    private float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            ThrowAxe();
        }

        if (Input.GetButton("Fire2"))
        {
            ReturnAxe();
        }

        if(isReturning)
        {
            if(time<1.0f)
            {
                axe.position = getBQCPoint(time, old_pos, curve_point.position, target.position);
                axe.rotation = Quaternion.Slerp(axe.transform.rotation, target.rotation, 50 * Time.deltaTime);
                time += Time.deltaTime;
            }
            else
            {
                ResetAxe();
            }
        }
    }

    void ThrowAxe()
    {
        axe.transform.parent = null;
        axe.isKinematic = false;
        axe.AddForce(Camera.main.transform.TransformDirection(Vector3.forward) * throwForce, ForceMode.Impulse);
        axe.AddTorque(axe.transform.TransformDirection(Vector3.right)*100, ForceMode.Impulse);

    }

    void ReturnAxe()
    {
        time = 0.0f;
        old_pos = axe.position;
        isReturning = true;
        axe.velocity= Vector3.zero;
        axe.isKinematic = true;
    }

    Vector3 getBQCPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }

    void ResetAxe()
    {
        isReturning = false;
        axe.transform.parent = transform;
        axe.position = target.position;
        axe.rotation = target.rotation;
    }
}
