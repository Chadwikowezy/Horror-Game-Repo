﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float drag = .5f;

    public Vector3 moveVector { set; get; }

    public VirtualJoystick joystick;
    private Rigidbody thisRigidBody;
    private Transform camTransform;
    private HandleCanvas handleCanvas;

    void Start ()
    {
        thisRigidBody = GetComponent<Rigidbody>();
        thisRigidBody.drag = drag;
        handleCanvas = FindObjectOfType<HandleCanvas>();
    }

    void Update ()
    {
        //movement vector
        moveVector = PoolInput();
        //rotation vector
        moveVector = RotateWithView();

        Move();
    }

    public void Move()
    {
        if(handleCanvas.movementJoytickStop == false)
        {
            if (thisRigidBody.velocity.magnitude < 6)
            {              
                thisRigidBody.velocity = (moveVector * moveSpeed);
            }
        }
        
    }

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
}
