using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    public int numberSpawn;
    public GameObject objectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberSpawn; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(185.0f, 400.0f), transform.position.y + 10f, Random.Range(75.0f, 300.0f));
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
