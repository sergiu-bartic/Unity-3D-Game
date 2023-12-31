using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger1 : MonoBehaviour
{
    public float biteRate = 1f;
    public float damage = 10f;

    private float nextTimeToBite = 0f;
    public GameObject effect;
    public GameObject player;
    private Target3 target3;

    // Start is called before the first frame update
    void Start()
    {
        target3 = player.GetComponent<Target3>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Time.time >= nextTimeToBite && target3 != null)
        {
            nextTimeToBite = Time.time + 1f / biteRate;
            target3.TakeDamage(damage);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
}
