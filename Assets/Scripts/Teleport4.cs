using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Teleport4 : MonoBehaviour
{
    PlayerMovement playerController;

    [SerializeField] GameObject TeleportPlace1;
    [SerializeField] GameObject TeleportPlace2;
    [SerializeField] GameObject TeleportPlace3;

    Vector3 TP1Location;
    Vector3 TP2Location;
    Vector3 TP3Location;

    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerMovement>();

        TP1Location = TeleportPlace1.transform.position;
        TP2Location = TeleportPlace2.transform.position;
        TP3Location = TeleportPlace3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(StopMoveToTeleport(TP1Location));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(StopMoveToTeleport(TP2Location));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(StopMoveToTeleport(TP3Location));

        }
    }

    void Teleport(Vector3 TPLocation0)
    {
        gameObject.transform.position = TPLocation0;
        Debug.Log(TPLocation0 + "TELEPORT4!!!");
    }

    IEnumerator StopMoveToTeleport(Vector3 TPLocation)
    {
        playerController.disabled = true;
        yield return null;
        Teleport(TPLocation);
        yield return null;
        playerController.disabled = false;
    }
}
