using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport3 : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("Teleport");
            Debug.Log("TELEPORT3");
        }
    }

    IEnumerator Teleport()
    {
        playerController.disabled = true;
        yield return new WaitForSeconds(1f);
        player.transform.position = new Vector3(260f, 10f, 12f);
        yield return new WaitForSeconds(1f);
        playerController.disabled = false;
    }
}
