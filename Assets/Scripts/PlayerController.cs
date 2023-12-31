using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool disabled = false;
    public float MoveSpeed = 10f;

    /*public GameObject interactWith;
    public GameObject interactCollider;

    public Camera cameraObject;

    [SerializeField] Transform playerCamera = null; 
    [SerializeField] float mouseSensitivity = 2f;
    float walkSpeed = 1.5f;
    float runSpeed = 2.0f;
    float gravity = -13.0f;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.15f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.15f;

    //AudioSource FootStepsAudio;
    bool isWalking = false;
    //bool isStepping = false;
    bool isRunning = false;

    [SerializeField] bool lockCursor = true;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    bool canUseHeadBob = true;

    //[Header("Headbob Parameters")]
    private float walkBobSpeed = 7f;
    private float walkBobAmount = 0.05f;
    private float sprintBobSpeed = 10f;
    private float sprintBobAmount = 0.05f;
    private float defaultYPos = 1.9f;
    private float timer;

    float lastLocation;
    float currentLocation;
    bool playFootstep = false; */

    private void Awake()
    {
        /*defaultYPos = cameraObject.transform.localPosition.y;
        currentLocation = playerCamera.transform.localPosition.y; */
    }

    // Start is called before the first frame update
    void Start()
    {
        /*interactWith = gameObject; 

        controller = GetComponent<CharacterController>();

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } */

        //FootStepsAudio = gameObject.GetComponent<AudioSopurse>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled)
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            transform.position += direction * MoveSpeed * Time.deltaTime;
            transform.LookAt(transform.position + direction);

            /*UpdateMouseLook();
            UpdateMovement();

            InteractCheck();

            if (canUseHeadBob)
            {
                HandleHeadBob();
            } */
        }
    }

    void UpdateMouseLook()
    {
        /*Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;

        .Clamp(cameraPitch, -90.0f, 90.0f);
        EulerAngles = Vector3.right * cameraPitch;

        Vector3.up*currentMouseDelta.x*mouseSensitivity); */
        }

        void UpdateMovement()
    {

    }

    void InteractCheck()
    {

    }

    void HandleHeadBob()
    {

    }
}
