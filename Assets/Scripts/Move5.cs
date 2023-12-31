using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move5 : MonoBehaviour
{
    //Transform SetPosition

    public float forceMult = 5;
    public float MoveSpeed = 10f;


    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * forceMult * Time.deltaTime;
    }
}
