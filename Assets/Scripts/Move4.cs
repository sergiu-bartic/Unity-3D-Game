using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move4 : MonoBehaviour
{
    //Transform Translate

    public float forceMult = 5;
    public float MoveSpeed = 10f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * forceMult * Time.deltaTime);
    }
}
