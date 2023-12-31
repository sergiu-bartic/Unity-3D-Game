using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrone1 : MonoBehaviour
{
    private Transform drone;

    private void Awake()
    {
        drone = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private Vector3 velocityCamera;
    public Vector3 behindPosition = new Vector3(0f, 2f, -4f);
    public float angle;

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, drone.transform.TransformPoint(behindPosition) + Vector3.up * Input.GetAxis("Vertical"), ref velocityCamera, 0.1f);
        transform.rotation = Quaternion.Euler(new Vector3(angle, drone.GetComponent<Drone1>().currentYRotation, 0f));
    }

}
