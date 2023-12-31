using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor2 : MonoBehaviour
{
    [SerializeField] private Image reticle;

    private void Start()
    {
        reticle = GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            reticle.color = Color.blue;
            Debug.Log("Blue");
        }
        else if (Input.GetMouseButton(1))
        {
            reticle.color = Color.green;
            Debug.Log("Green");
        }
        else
        {
            reticle.color = Color.black;
            Debug.Log("Black");
        }
    }
}