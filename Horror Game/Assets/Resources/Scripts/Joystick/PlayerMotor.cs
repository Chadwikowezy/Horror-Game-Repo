using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    #region variables
    public float moveSpeed = 5f;
    public float drag = .5f;

    public Vector3 moveVector { set; get; }

    public VirtualJoystick joystick;
    private Rigidbody thisRigidBody;
    private Transform camTransform;
    private HandleCanvas handleCanvas;

    public bool isSprinting;
    public bool isGrounded;
    #endregion

    #region start
    void Start ()
    {
        thisRigidBody = GetComponent<Rigidbody>();
        thisRigidBody.drag = drag;
        handleCanvas = FindObjectOfType<HandleCanvas>();
    }
    #endregion

    #region update
    void Update ()
    {
        //movement vector
        moveVector = PoolInput();
        //rotation vector
        moveVector = RotateWithView();

        Move();
    }
    #endregion

    #region move function call, and stopping/ reseting movespeed 
    public void Move()
    {
        if(handleCanvas.movementJoytickStop == false && isGrounded == true)
        {
            if (thisRigidBody.velocity.magnitude < 6)
            {              
                thisRigidBody.velocity = (moveVector * moveSpeed);
            }
            else if(thisRigidBody.velocity.magnitude == 0)
            {
                isGrounded = true;
            }
        }

       if (isGrounded == false)
            if (thisRigidBody.velocity.magnitude == 0)
                isGrounded = true;
    }

    public void ResetMoveSpeed()
    {
        moveSpeed = 5;
    }
    public void StopMovement()
    {
        moveSpeed = 0;
    }
    #endregion

    #region Vector3 returning functions for input values
    Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;
        //dir.x = Input.GetAxis("Horizontal");
        //dir.z = Input.GetAxis("Vertical");

        dir.x = joystick.Horizontal();
        dir.z = joystick.Vertical();

        if (dir.magnitude > 1)
        {
            dir.Normalize();
        }
        return dir;
    }
    Vector3 RotateWithView()
    {
        if (camTransform != null)
        {
            Vector3 dir = camTransform.TransformDirection(moveVector);
            dir.Set(dir.x, 0, dir.z);
            return dir.normalized * moveVector.magnitude;
        }
        else
        {
            camTransform = GetComponent<CameraMotor>().camTransform;
            return moveVector;
        }
    }
    #endregion

    #region OnCollisionEnter & OnCollisionExit functions
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    #endregion
}
