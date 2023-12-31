using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport7 : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = teleportTarget.transform.position;
        Debug.Log("SAFE1");
    }
    private void OnTriggerStay(Collider other)
    {
        other.transform.position = teleportTarget.transform.position;
        Debug.Log("SAFE2");
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.position = teleportTarget.transform.position;
        Debug.Log("SAFE3");
    }
}
