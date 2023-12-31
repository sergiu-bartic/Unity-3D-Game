using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    //Rigidbody SetVelocity

    public float forceMult = 200;
    public float MoveSpeed = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * forceMult * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
