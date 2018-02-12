using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCamera : MonoBehaviour
{
    public Transform targetCameraPos;
    public Transform lookTarget;

    public float moveSpeed;
    public float rotSpeed;

    private Quaternion camRotation;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetCameraPos.position, moveSpeed * 1f);

        rotateCamera();
    }

    void rotateCamera()
    {
        if (lookTarget == null)
        {
            camRotation = Quaternion.Slerp(transform.rotation, targetCameraPos.rotation, rotSpeed * 0.1f);
        }
        else
        {
            Quaternion lookRot = Quaternion.LookRotation(lookTarget.position - transform.position);
            camRotation = Quaternion.Slerp(transform.rotation, lookRot, rotSpeed * 0.1f); 
        }

        transform.localRotation = camRotation;
    }
}
