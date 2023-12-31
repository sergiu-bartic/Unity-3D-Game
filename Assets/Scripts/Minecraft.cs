using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecraft : MonoBehaviour
{
    public Vector2 CameraSpeed = new Vector2(180, 180);

    public float MoveSpeed = 10f;
    private float Pitch = 0f;
    private float Yaw = 0f;

    private RaycastHit Hit;

    public GameObject BlockPrefab;
    public GameObject BlockOutLine;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //look around
        Pitch += -Input.GetAxis("Mouse Y") * CameraSpeed.x * Time.deltaTime;
        Yaw += Input.GetAxis("Mouse X") * CameraSpeed.y * Time.deltaTime;

        Camera.main.transform.eulerAngles = new Vector3(Pitch, Yaw, 0);

        //get input values
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Fly");
        float inputZ = Input.GetAxis("Vertical");

        //directions
        Vector3 dirForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;
        Vector3 dirSide = Camera.main.transform.right;
        Vector3 dirUp = Vector3.up;

        Vector3 moveDir = (inputX * dirSide) + (inputY * dirUp) + (inputZ * dirForward);
        Camera.main.transform.position += moveDir * MoveSpeed * Time.deltaTime;

        //raycast
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        //looking at a block
        if (Physics.Raycast(ray, out Hit))
        {
            Vector3 pos = Hit.point;

            //move away from the surface slightly
            pos += Hit.normal * 0.1f;

            //round the position values to whole numbers
            pos = new Vector3(Mathf.Floor(pos.x), Mathf.Floor(pos.y), Mathf.Floor(pos.z));

            //offset position by half a block
            pos += Vector3.one * 0.5f;

            //set outline block position for preview
            BlockOutLine.transform.position = pos;

            //left click
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(BlockPrefab, pos, Quaternion.identity);
            }

            //right click
            else if (Input.GetMouseButtonDown(1))
            {
                if (Hit.collider.name == "BlockGrass(Clone)")
                    Destroy(Hit.collider.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Camera ray
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 99999);

        //collision point
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Hit.point, 0.05f);

        //surface direction
        Gizmos.DrawRay(Hit.point, Hit.normal);
    }
}
