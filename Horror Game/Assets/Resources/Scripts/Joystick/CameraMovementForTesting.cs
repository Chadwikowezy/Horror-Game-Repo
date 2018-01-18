using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementForTesting : MonoBehaviour
{
    public float camSpeed;
    public float lookSensitivity;

    private Vector3 rotation;

	void Start ()
    {
		
	}
	void FixedUpdate ()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * camSpeed);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.forward * -camSpeed);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * camSpeed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.right * -camSpeed);

        if (Input.GetKey(KeyCode.Space))
            transform.Translate(Vector3.up * camSpeed);
        if (Input.GetKey(KeyCode.LeftShift))
            transform.Translate(Vector3.up * -camSpeed);

        //Cam rotation
        rotation.y += lookSensitivity * Input.GetAxis("Mouse X");
        rotation.x -= lookSensitivity * Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -90, 90);
        transform.eulerAngles = rotation;
    }
}
