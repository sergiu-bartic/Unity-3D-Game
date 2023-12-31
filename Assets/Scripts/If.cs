using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class If : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public bool Yes;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(240.20f, 260.0f), transform.position.y, Random.Range(100.20f, 200.0f));

        if (Yes)
            Instantiate(object1, randomPosition, Quaternion.identity);
        else
            Instantiate(object2, randomPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
