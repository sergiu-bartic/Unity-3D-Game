using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport6 : MonoBehaviour
{
    public Vector3 place;
    private RaycastHit _Hit;

    [SerializeField] GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _Hit))
        {
            place = new Vector3(_Hit.point.x, _Hit.point.y + 3f, _Hit.point.z);

            if(Input.GetMouseButtonDown(1))
            {
                Debug.Log(_Hit.transform.name);
                Target target = _Hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    player = target.gameObject;
                }
            }

            if (_Hit.transform.tag == "Terrain")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    player.SetActive(false);
                    player.transform.position = place;
                    player.SetActive(true);
                    Debug.Log("Merge");
                }
            }
        }
    }
}
