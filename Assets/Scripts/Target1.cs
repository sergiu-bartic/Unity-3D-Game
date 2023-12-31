using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Target1 : MonoBehaviour
{
    PlayerMovement playerController;

    [SerializeField] GameObject TeleportRespawn;

    Vector3 TPRespawn;

    public float health = 50f;

    private void Start()
    {
        playerController = gameObject.GetComponent<PlayerMovement>();

        TPRespawn = TeleportRespawn.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Respawn();
            Debug.Log("Take damage");

        }
    }

    void Respawn()
    {
        StartCoroutine(StopMoveToTeleport(TPRespawn));
    }

    void Teleport(Vector3 TPLocation)
    {
        gameObject.transform.position = TPLocation;
        Debug.Log(TPLocation + "Respawn!!!");
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
