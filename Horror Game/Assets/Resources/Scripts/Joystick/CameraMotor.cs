using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    #region variables
    private const float Y_ANGLE_MIN = -30;
    private const float Y_ANGLE_MAX = 30;

    public GameObject camerasPrefab;

    public float movSpeed;
    public float lookDamp;

    public VirtualJoystick joystick;

    public Transform lineOfSight;

    public Transform playerCam;//swtiched from cam main to head

    public Transform camTargetPos;

    public Transform camTransform { get; set; }

    private float distance = .001f;
    private float currentX = 135f;
    private float currentY = 0f;
    public float yCamLimit = 0f;
    public float sensitivityX = .2f;
    public float sensitivityY = .2f;

    public GameObject playerAnimObj;
    public Transform cameraChild;
    private HandleCanvas handleCanvas;
    private InsanityManager insanityManager;
    public Transform crouchLOS_OBJ;

    private Vector3 dir;
    private Vector3 targetEuler;
    private Quaternion lookRotation;
    #endregion

    #region start
    void Start ()
    {
        camTransform = Camera.main.transform;
        handleCanvas = FindObjectOfType<HandleCanvas>();
        insanityManager = FindObjectOfType<InsanityManager>();

        if (playerCam == null)
            playerCam = Instantiate(camerasPrefab, transform.position, transform.rotation).transform;
    }
    #endregion

    #region LateUpdate
    void LateUpdate()
    {
        if(handleCanvas.canUseButtons == true)
        {
            currentX += joystick.Horizontal() * sensitivityX;

            currentY += -joystick.Vertical() * sensitivityY;
            currentY = ClampAngle(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

            dir = new Vector3(0, .75f, -distance);
        }     
    }
    #endregion

    #region FixedUpdate
    void FixedUpdate()
    {
        playerCam.position = camTargetPos.transform.position;
        if(handleCanvas.canUseButtons == true)
        {
            cameraRotation();
        }
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

    void cameraRotation()
    {
        Vector3 newEuler = camTargetPos.rotation.eulerAngles;

        targetEuler.x += -joystick.Vertical() * sensitivityY;
        targetEuler.x = Mathf.Clamp(targetEuler.x, -yCamLimit, yCamLimit);
        targetEuler.y = 0;
        targetEuler.z = 0;

        lookRotation = Quaternion.Slerp(playerCam.transform.rotation, Quaternion.Euler(newEuler + targetEuler), lookDamp * Time.fixedDeltaTime);

        playerCam.rotation = lookRotation;
    }

    public void MonsterAttackEffect()//Chad - for spector attack
    {
        handleCanvas.canUseButtons = false;
        Spector spector = FindObjectOfType<Spector>();

        Vector3 playerDir = new Vector3(spector.transform.position.x, transform.position.y, spector.transform.position.z);
        transform.LookAt(playerDir);

        Vector3 camDir = new Vector3(spector.transform.position.x, playerCam.transform.position.y, spector.transform.position.z);
        playerCam.transform.LookAt(camDir);

        Vector3 animObjDir = new Vector3(spector.transform.position.x, playerAnimObj.transform.position.y, spector.transform.position.z);
        playerAnimObj.transform.LookAt(animObjDir);

        StartCoroutine(AttackDelay());
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Spector spector = FindObjectOfType<Spector>();
        Vector3 monsterDir = new Vector3(spector.transform.position.x, transform.position.y, spector.transform.position.z);
        Vector3 knockbackDir = monsterDir - transform.position;

        GetComponent<Rigidbody>().AddForce(-knockbackDir.normalized * 500f);
        yield return new WaitForSeconds(.5f);
        insanityManager.AlterInsanity(1);
        handleCanvas.canUseButtons = true;
    }
}
