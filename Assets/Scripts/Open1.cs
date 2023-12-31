using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Open1 : MonoBehaviour
{
    private bool IsClose = true;
    [SerializeField] Transform Door;
    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Text=FindObjectOfType<TextMeshProUGUI>();
        Text.text = "Door Open Open";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && IsClose)
        {
            Door.localEulerAngles = Vector3.up * 80;
            Text.text = "Door Open";
            IsClose = false;
            Debug.Log("Open");
        }
        else if (other.tag == "Player" && Input.GetKeyDown(KeyCode.I))
        {
            Door.localEulerAngles = Vector3.up * 0;
            Text.text = "Door Close";
            IsClose = true;
            Debug.Log("Close");
        }
    }
}
