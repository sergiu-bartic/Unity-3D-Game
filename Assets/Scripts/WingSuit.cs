using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingSuit : MonoBehaviour
{
    public float speed = 12.5f;
    public float drag = 6;

    public Rigidbody rb;

    private Vector3 rot;
    public float percentage;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rot = transform.eulerAngles;
    }
    // Update is called once per frame
    void Update()
    {
        //Rotate the player
        //X
        rot.x += 20 * Input.GetAxis("Vertical") * Time.deltaTime;
        rot.x = Mathf.Clamp(rot.x, 0, 45);
        //Y
        rot.x += 20 * Input.GetAxis("Horizontal") * Time.deltaTime;
        //Z
        rot.z += -5 * Input.GetAxis("Horizontal");
        rot.z = Mathf.Clamp(rot.x, -5, 5);
        transform.rotation=Quaternion.Euler(rot);

        percentage = rot.x / 45;
        //Drag: Fast(4), Slow(6)
        float mod_drag = (percentage * -2) + 6;
        //Speed: Fast(13.8), Slow(12.5)
        float mod_speed=percentage * (13.8f-12.5f) + 12.5f;

        rb.drag = mod_drag;
        Vector3 localV = transform.InverseTransformDirection(rb.velocity);
        localV.z = mod_speed;
        rb.velocity = transform.TransformDirection(localV);
    }
}

/*other script for camera
 * public class CameraShake : MonoBehaviour
 * {
 *  public WingsuitControler wc;
 *  public float shaking=0.5f;
 *  
 *  private void LateUpdate()
 *  {
 *      float mod_shaking=shaking*wc.percentage;
 *      transform.localPosition=new Vector3(Random.Range(-mod_shaking,mod_shaking), Random.Range(-mod_shaking,mod_shaking),0);
 *      }
 *      }
 *      */