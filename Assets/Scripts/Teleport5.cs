using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport5 : MonoBehaviour
{
    public Vector3 place;
    private RaycastHit _Hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _Hit))
        {
            place = new Vector3(_Hit.point.x, _Hit.point.y + 10f, _Hit.point.z);

            if (_Hit.transform.tag == "Terrain")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    this.gameObject.SetActive(false);
                    transform.position = place;
                    this.gameObject.SetActive(true);
                    Debug.Log("Merge");
                }
            }
        }
    }
}
