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
    public float sensitivityX = .6f;
    public float sensitivityY = .6f;

    public GameObject playerAnimObj;
    public Transform cameraChild;
    public bool isAnimating;
    public Transform crouchLOS_OBJ;

    void Start ()
    {
        camTransform = Camera.main.transform;
        cam = Camera.main;
    }
	
	void Update ()
    {
        Vector3 animDir = new Vector3(cameraChild.position.x, playerAnimObj.transform.position.y, cameraChild.position.z);
        playerAnimObj.transform.LookAt(animDir);

        currentX += joystick.Horizontal() * sensitivityX;

        currentY += -joystick.Vertical() * sensitivityY;
        currentY = ClampAngle(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, .75f, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = Vector3.Lerp(transform.position, this.transform.position + rotation * dir, 1);

        if (isAnimating == false)
        {           
            camTransform.LookAt(thisTransform.position);
        }
        else if (isAnimating == true)
        {
            camTransform.LookAt(crouchLOS_OBJ.position);
        }
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
