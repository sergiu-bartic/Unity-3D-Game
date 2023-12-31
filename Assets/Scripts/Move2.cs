using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    //Rigidbody MovePosition

    public float forceMult = 5;
    public float MoveSpeed = 10f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position + (transform.forward * forceMult * Time.deltaTime);
        rb.MovePosition(newPosition);
    }
}
