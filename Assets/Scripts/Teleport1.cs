using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Col)
    {
        Col.transform.position = new Vector3(Random.Range(240.0f, 260.0f), Col.transform.position.y, Random.Range(10.0f, 20.0f));
    }
}
