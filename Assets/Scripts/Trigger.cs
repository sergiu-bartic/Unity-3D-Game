using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("IT Work!!! Enter"/* + Random.Range(0, 9)*/);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("IT Work!!! Stay"/* + Random.Range(10, 19)*/);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("IT Work!!! Exit"/* + Random.Range(20, 29)*/);
        }
    }

}
