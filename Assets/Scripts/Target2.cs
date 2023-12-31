using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Target2 : MonoBehaviour
{
    [SerializeField] GameObject TeleportRespawn;

    Vector3 TPRespawn;

    public float health0 = 500f;
    public float biteRate = 1f;

    public float health = 500f;
    private float nextTimeToBite = 0f;

    private void Start()
    {
        TPRespawn = TeleportRespawn.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && Time.time >= nextTimeToBite)
        {
            Debug.Log("Take damage");
            nextTimeToBite = Time.time + 1f / biteRate;
            TakeDamage(10f);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Respawn(TPRespawn);
            Debug.Log("Take damage Take damage");

        }
    }

    void Respawn(Vector3 TPLocation)
    {
        gameObject.transform.position = TPLocation;
        health = health0;
        Debug.Log(TPLocation + "Respawn!!!");
    }
}
