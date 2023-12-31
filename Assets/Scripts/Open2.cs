using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SocialPlatforms;

public class Open2 : MonoBehaviour
{
    [SerializeField] private bool openTrigger = true;
    [SerializeField] private bool closeTrigger = false;
    [SerializeField] Transform Door;
    public float biteRate = 1f;
    private float nextTimeToBite = 0f;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && openTrigger && Time.time >= nextTimeToBite)
        {
            nextTimeToBite = Time.time + 1f / biteRate;
            Door.localEulerAngles = Vector3.up * 80;
            Debug.Log("Open Open");
        }
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && closeTrigger)
        {
            Door.localEulerAngles = Vector3.up * 0;
            Debug.Log("Close Close");
        }
    }
}
