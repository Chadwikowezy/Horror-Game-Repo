using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -45;
    private const float Y_ANGLE_MAX = 0;

    public VirtualJoystick joystick;

    public Transform thisTransform;
    private Camera cam;
    public Transform camTransform { get; set; }

    private float distance = .001f;
    private float currentX = 0f;
    private float currentY = 0f;
    private float sensitivityX = .6f;
    private float sensitivityY = .6f;

    void Start ()
    {
        camTransform = Camera.main.transform;
        cam = Camera.main;
    }
	
	void Update ()
    {
        currentX += joystick.Horizontal() * sensitivityX;

        currentY += -joystick.Vertical() * sensitivityY;
        currentY = ClampAngle(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        Debug.Log(currentY);
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, .75f, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = this.transform.position + rotation * dir;

        camTransform.LookAt(thisTransform.position);

        camTransform.position = thisTransform.position;
    }

    float ClampAngle(float angle, float min, float max)
    {
        do
        {
            if (angle < -360)
            {
                angle += 360;
            }
            if (angle > 360)
            {
                angle -= 360;
            }
        } while (angle < -360 || angle > 360);

        return Mathf.Clamp(angle, min, max);
    }
}
