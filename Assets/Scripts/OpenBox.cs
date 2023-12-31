using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    private bool IsClose = true;
    [SerializeField] Transform Door;
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && IsClose)
        {
            Door.localEulerAngles = Vector3.right * -75;
            IsClose = false;
            Text.SetActive(true);
            Debug.Log("Open");
        }
        else if (other.tag == "Player" && Input.GetKeyDown(KeyCode.I))
        {
            Door.localEulerAngles = Vector3.up * 0;
            IsClose = true;
            Text.SetActive(false);
            Debug.Log("Close");
        }
    }
}
