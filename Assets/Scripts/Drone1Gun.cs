using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone1Gun : MonoBehaviour
{
    public Transform gunTransform;
    public GameObject bulletPrefab;
    public float fireRate = 6f;
    private float waitTillNextFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        ShootingBullets();
    }

    void ShootingBullets()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (waitTillNextFire <= 0f)
            {
                Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
                waitTillNextFire = 1f;
            }
        }
        waitTillNextFire -= fireRate * Time.deltaTime;
    }
}
