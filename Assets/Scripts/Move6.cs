using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move6 : MonoBehaviour
{
    public float speed = 12f;

    public bool disabled = false;

    // Update is called once per frame
    void Update()
    {
        if (!disabled)
        {
            Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            transform.position = transform.position + playerInput.normalized * speed * Time.deltaTime;
        }
    }
}
