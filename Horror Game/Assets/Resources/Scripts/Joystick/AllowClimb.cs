using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowClimb : MonoBehaviour
{
    private PlayerMotor player;
    public GameObject head;
    private HandleCanvas handleCanvas;

    public GameObject climbButton;

    public bool isClimbing;
    public bool canClimb;

    public Transform lookPos;
    public Transform moveToPos;

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
            climbButton.SetActive(false);

            handleCanvas.canUseButtons = false;

            Vector3 playerDir = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
            player.transform.LookAt(playerDir);

            head.transform.LookAt(lookPos.position);

            StartCoroutine(ClimbPhase());
        }
        else
        {
            player.GetComponent<Rigidbody>().useGravity = true;
        }        
    }
    IEnumerator ClimbPhase()
    {
        yield return new WaitForSeconds(1f);
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * .25f);
        player.GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * .25f);
        yield return new WaitForSeconds(1f);
    }

    public void ClimbButtonEvent()
    {       
        player.transform.position = moveToPos.position;        
        isClimbing = true;
        climbButton.SetActive(false);
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.GetComponent<PlayerMotor>())
        {
            canClimb = true;
        }
    }
  
    IEnumerator ReturnControl()
    {
        yield return new WaitForSeconds(1f);
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerMotor>())
        {
            player.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1f);
            player.GetComponent<Rigidbody>().useGravity = true;
            canClimb = false;
            isClimbing = false;
            handleCanvas.canUseButtons = true;
            climbButton.SetActive(false);
        }
    }
}
