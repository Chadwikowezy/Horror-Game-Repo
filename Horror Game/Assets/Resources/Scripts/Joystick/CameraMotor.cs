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
    private Quaternion rotation;
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
        currentX += joystick.Horizontal() * sensitivityX;

        currentY += -joystick.Vertical() * sensitivityY;
        currentY = ClampAngle(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);


        dir = new Vector3(0, .75f, -distance);
        rotation = Quaternion.Euler(currentY, currentX, 0);
    }
    #endregion

    #region FixedUpdate
    void FixedUpdate()
    {
        playerCam.position = camTargetPos.transform.position;
        cameraRotation();
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
        Vector3 targetEuler = camTargetPos.rotation.eulerAngles;

        targetEuler.x = targetEuler.x + -joystick.Vertical() * yCamLimit;
        targetEuler.z = 0;
        lookRotation = Quaternion.Slerp(playerCam.transform.rotation, Quaternion.Euler(targetEuler), sensitivityX * 0.01f);

        playerCam.rotation = lookRotation;
    }

    public void MonsterAttackEffect()//Chad - for spector attack
    {
        handleCanvas.canUseButtons = false;
        Spector spector = FindObjectOfType<Spector>();

        Vector3 monsterDir = new Vector3(spector.transform.position.x, transform.position.y + 0.5f, spector.transform.position.z);
        transform.LookAt(monsterDir);

        playerCam.transform.LookAt(monsterDir);
        playerAnimObj.transform.LookAt(monsterDir);

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
