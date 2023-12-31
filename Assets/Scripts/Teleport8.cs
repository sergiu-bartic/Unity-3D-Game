using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport8 : MonoBehaviour
{
    [SerializeField] Transform Gate;
    [SerializeField] GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = new Vector3(Gate.position.x, Gate.position.y, Gate.position.z);
        yield return new WaitForSeconds(1);
    }
}
