using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    #region variables
    public float moveSpeed = 5f;
    public float drag = .5f;
    public float sensitivity = 1;

    public enum animStates { IDLE, WALK, RUN, HOLDPHONE };
    public animStates currentState;

    public Vector3 moveVector { set; get; }

    public VirtualJoystick joystick;
    public VirtualJoystick rotJoystick;
    private Rigidbody thisRigidBody;
    private Transform camTransform;
    private HandleCanvas handleCanvas;

    public bool onPhone = false;

    public bool isSprinting;
    public bool isGrounded;

    private Vector3 newRot;
    #endregion

    #region start
    void Start ()
    {
        thisRigidBody = GetComponent<Rigidbody>();
        thisRigidBody.drag = drag;
        handleCanvas = FindObjectOfType<HandleCanvas>();
        Physics.IgnoreLayerCollision(0, 13);
    }
    #endregion

    #region update
    void Update ()
    {
        //movement vector
        moveVector = PoolInput();

        ControlStates();
    }
    #endregion
    #region FixedUpdate
    private void FixedUpdate()
    {
        Move();
    }
    #endregion


    #region move function call, and stopping/ reseting movespeed 
    public void Move()
    {
        if(handleCanvas.canUseButtons == true && isGrounded == true)
        {
            if (thisRigidBody.velocity.magnitude < 6)
            {              
                thisRigidBody.velocity = (transform.TransformDirection(moveVector) * moveSpeed);
            }           
            else if(thisRigidBody.velocity.magnitude == 0)
            {
                isGrounded = true;
            }

            RotatePlayer();
        }       
       /*if (isGrounded == false)
            if (thisRigidBody.velocity.magnitude == 0)
                isGrounded = true;*/
    }

    void ControlStates()
    {
        //if (onPhone == false)
        //{
            if (thisRigidBody.velocity.magnitude > 4 && thisRigidBody.velocity.magnitude <= 6)
            {
                currentState = animStates.RUN;
            }
            if (thisRigidBody.velocity.magnitude > 0.1f && thisRigidBody.velocity.magnitude <= 4)
            {
                currentState = animStates.WALK;
            }
            else if (thisRigidBody.velocity.magnitude <= 0.1f)
            {
                currentState = animStates.IDLE;
            }
        //}
        //else if(onPhone == true)
        //{
        //    currentState = animStates.HOLDPHONE;
        //}
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
    void RotatePlayer()
    {
        newRot.y += rotJoystick.Horizontal() * sensitivity;

        transform.rotation = Quaternion.Euler(newRot);
    }
    #endregion

    #region OnCollisionEnter & OnCollisionExit functions
    void OnCollisionStay(Collision other)
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
