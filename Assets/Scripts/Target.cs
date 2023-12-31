using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public GameObject BlockPrefab;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        { 
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Instantiate(BlockPrefab, transform.position, Quaternion.identity);
    }
}
