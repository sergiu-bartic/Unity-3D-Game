using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingController : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public Transform Ball;
    public Transform Arms;
    public Transform PosOverHead;
    public Transform PosDribble;
    public Transform Target;

    private bool IsBallInHands = true;
    private bool IsBallFlying = false;

    private float T = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.position += direction * MoveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + direction);
        
        //ball in hands
        if(IsBallInHands)
        {
            //hold over head
            if(Input.GetKey(KeyCode.Y))
            {
                Ball.position = PosOverHead.position;
                Arms.localEulerAngles = Vector3.right * 180;

                //look towards the target
                transform.LookAt(Target.parent.position);
            }

            //dribbling
            else
            {
                Ball.position = PosDribble.position + Vector3.up * 3.5f * Mathf.Abs(Mathf.Sin(Time.time * 5));
                Arms.localEulerAngles = Vector3.right * -60;
            }

            //throw ball
            if (Input.GetKeyUp(KeyCode.Y))
            {
                IsBallInHands = false;
                IsBallFlying = true;
                T = 0;
            }
        }

        //ball in the air
        if(IsBallFlying)
        {
            T += Time.deltaTime;
            float duration = 0.5f;
            float t01 = T / duration;

            Vector3 A = PosOverHead.position;
            Vector3 B = Target.position;
            Vector3 pos = Vector3.Lerp(A, B, t01);

            //move in arc
            Vector3 arc = Vector3.up * Mathf.Sin(t01 * 3.14f);

            Ball.position = pos + arc;

            //moment when ball arrives at target
            if(t01>=1)
            {
                IsBallFlying = false;
                Ball.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsBallInHands && !IsBallFlying)
        {
            IsBallInHands = true;
            Ball.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
