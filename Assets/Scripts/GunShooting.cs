using System.Collections;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public float damage = 10f;
    public float range = 5f;
    public float fireRate = 1f;
    public float impactForce = 150f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 5f;
    private bool isReloading = false;

    public Camera fpsCam;
    private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if(currentAmmo==-1)
            currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return; //stop here

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return; //stop here
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) //if I use Input.GetButtonDown will fire when I click the button, but now fire automatically
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null) 
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce); //force on a target, move the target
            }

        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
