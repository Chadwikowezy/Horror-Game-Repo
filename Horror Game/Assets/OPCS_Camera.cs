using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPCS_Camera : MonoBehaviour
{
    public Transform targetCamPos;
    public Transform target;

    public List<Transform> panRotTransforms = new List<Transform>();

    public float moveSpeed;
    public float rotSpeed;

    private Quaternion camRotation;

	void FixedUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, targetCamPos.position, moveSpeed * 0.1f);

        RotateCam();
    }
	
	void RotateCam()
    {
        if(target == null)
        {
            camRotation = Quaternion.Slerp(transform.rotation, targetCamPos.rotation, rotSpeed * 0.1f);
        }
        else
        {
            Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position);
            camRotation = Quaternion.Slerp(transform.rotation, lookRot, rotSpeed * 0.1f);
        }
        transform.localRotation = camRotation;
    }
}
