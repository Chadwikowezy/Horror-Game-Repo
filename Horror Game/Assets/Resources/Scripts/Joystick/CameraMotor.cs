using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -30;
    private const float Y_ANGLE_MAX = 30;  

    public VirtualJoystick joystick;

    public Transform lineOfSight;
    private Camera cam;
    public Transform camTransform { get; set; }

    private float distance = .001f;
    private float currentX = 0f;
    private float currentY = 0f;
    public float sensitivityX = .2f;
    public float sensitivityY = .2f;

    public GameObject playerAnimObj;
    public Transform cameraChild;
    public bool isAnimating;
    public Transform crouchLOS_OBJ;

    private Vector3 dir;
    private Quaternion rotation;

    void Start ()
    {
        camTransform = Camera.main.transform;
        cam = Camera.main;
    }

    void LateUpdate()
    {
        currentX += joystick.Horizontal() * sensitivityX;

        currentY += -joystick.Vertical() * sensitivityY;
        currentY = ClampAngle(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);


        dir = new Vector3(0, .75f, -distance);
        rotation = Quaternion.Euler(currentY, currentX, 0);
        //camTransform.position = Vector3.Lerp(transform.position, this.transform.position + rotation * dir, 1); 
    }

    void FixedUpdate()
    {
        if (isAnimating == false)
        {
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, rotation, Time.deltaTime * 5);

            Vector3 animDir = new Vector3(cameraChild.position.x, playerAnimObj.transform.position.y, cameraChild.position.z);
            playerAnimObj.transform.LookAt(animDir);
        }
        else if (isAnimating == true)
        {
            camTransform.LookAt(crouchLOS_OBJ.position);
        }
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
