using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowClimb : MonoBehaviour
{
    private PlayerMotor player;
    private HandleCanvas handleCanvas;

    public GameObject climbButton;
    public Animator playerAnimObj;

    public bool isClimbing;
    private bool canClimb;

    private Vector3 climbOrientation = new Vector3(0, 0, 0);

	void Start ()
    {
        player = FindObjectOfType<PlayerMotor>();
        handleCanvas = FindObjectOfType<HandleCanvas>();
    }
	
	void Update ()
    {
        //CheckPlayerDistance();

        if (isClimbing == true && canClimb == true)
        {
            handleCanvas.canUseButtons = false;
            playerAnimObj.SetInteger("Idle", 0);
            playerAnimObj.SetInteger("Walk", 0);
            playerAnimObj.SetInteger("Run", 0);
            playerAnimObj.SetInteger("Phone", 0);
            //playerAnimObj.SetInteger("Climb", 1);
            Vector3 playerDir = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            player.transform.LookAt(playerDir);

            player.GetComponentInChildren<Camera>().transform.LookAt(transform.position);
            player.GetComponent<Rigidbody>().useGravity = false;
            player.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1f);
            player.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * 1f);
        }
    }

    public void ClimbButtonEvent()
    {
        isClimbing = true;
        climbButton.SetActive(false);
    }

    void CheckOrientation()
    {
        if(enabled == true && isClimbing == false)
        {
            RaycastHit hit;
            if(Physics.Raycast(player.transform.position, player.transform.forward, out hit, 5f))
            {
                if(hit.collider.GetComponent<AllowClimb>())
                {

                }
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.GetComponent<PlayerMotor>())
        {
            canClimb = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerMotor>())
        {
            climbButton.SetActive(true);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerMotor>())
        {
            player.GetComponent<Rigidbody>().useGravity = true;
            handleCanvas.canUseButtons = true;
            canClimb = false;
            isClimbing = false;
            climbButton.SetActive(false);
        }
    }
}
