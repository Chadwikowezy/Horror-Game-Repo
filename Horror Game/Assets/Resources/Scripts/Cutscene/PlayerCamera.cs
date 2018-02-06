using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform positionTarget;
    public Transform lookTarget;

    public float moveSpeed;
    public float rotateSpeed;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, positionTarget.position, moveSpeed);
        rotateCam();
    }

    void rotateCam()
    {
        Vector3 _lookTarget = (lookTarget.position - transform.position).normalized;
        Quaternion newLookRotation = Quaternion.LookRotation(_lookTarget);

        transform.rotation = Quaternion.Slerp(transform.rotation, newLookRotation, rotateSpeed);
    }
}
