using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(objectToSpaw, Vector3.zero, Quaternion.identity);
        Instantiate(objectToSpawn, new Vector3(Random.Range(240.0f, 260.0f), transform.position.y, Random.Range(10.0f, 20.0f)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
