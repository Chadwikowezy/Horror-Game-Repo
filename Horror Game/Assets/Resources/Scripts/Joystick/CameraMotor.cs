using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    #region variables
    private const float Y_ANGLE_MIN = -30;
    private const float Y_ANGLE_MAX = 30;  

    public VirtualJoystick joystick;

    public Transform lineOfSight;

    public Transform head;//swtiched from cam main to head

    public Transform camTransform { get; set; }

    private float distance = .001f;
    private float currentX = 135f;
    private float currentY = 0f;
    public float sensitivityX = .2f;
    public float sensitivityY = .2f;

    public GameObject playerAnimObj;
    public Transform cameraChild;
    private HandleCanvas handleCanvas;
    private InsanityManager insanityManager;
    public Transform crouchLOS_OBJ;

    private Vector3 dir;
    private Quaternion rotation;
    #endregion

    #region start
    void Start ()
    {
        camTransform = Camera.main.transform;
        handleCanvas = FindObjectOfType<HandleCanvas>();
        insanityManager = FindObjectOfType<InsanityManager>();
    }
    #endregion

    #region LateUpdate
    void LateUpdate()
    {
        currentX += joystick.Horizontal() * sensitivityX;

        currentY += -joystick.Vertical() * sensitivityY;
        currentY = ClampAngle(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);


        dir = new Vector3(0, .75f, -distance);
        rotation = Quaternion.Euler(currentY, currentX, 0);
        //camTransform.position = Vector3.Lerp(transform.position, this.transform.position + rotation * dir, 1); 
    }
    #endregion

    #region FixedUpdate
    void FixedUpdate()
    {
        if (handleCanvas.canUseButtons == true)
        {
            head.transform.rotation = Quaternion.Lerp(head.transform.rotation, rotation, Time.deltaTime * 5);

            Vector3 animDir = new Vector3(cameraChild.position.x, playerAnimObj.transform.position.y, cameraChild.position.z);
            playerAnimObj.transform.LookAt(animDir);
        }
        /*else if (isAnimating == true)
        {
            camTransform.LookAt(crouchLOS_OBJ.position);
        }*/
    }
    #endregion

    #region ClampAngle float returning function
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
    #endregion

    public void MonsterAttackEffect()//Chad - for spector attack
    {
        handleCanvas.canUseButtons = false;
        Spector spector = FindObjectOfType<Spector>();

        Vector3 monsterDir = new Vector3(spector.transform.position.x, transform.position.y, spector.transform.position.z);
        transform.LookAt(monsterDir);


        head.transform.LookAt(monsterDir);
        playerAnimObj.transform.LookAt(monsterDir);

        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Spector spector = FindObjectOfType<Spector>();
        Vector3 knockbackDir = spector.transform.position - transform.position;

        GetComponent<Rigidbody>().AddForce(-knockbackDir * 50f);
        yield return new WaitForSeconds(.5f);
        insanityManager.AlterInsanity(1);
        handleCanvas.canUseButtons = true;
    }
}
