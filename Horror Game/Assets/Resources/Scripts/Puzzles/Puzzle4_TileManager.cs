using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4_TileManager : MonoBehaviour
{
    private InvisibleFloorPuzzleManager thisPuzzleManager;

    private PlayerMotor player;
    private Vector3 alertedPos;
    private Spector monster;
    private HandleCanvas handleCanvas;
    private Camera mainCamera;
    public GameObject arms;

    public bool hasFinishedProcess;

    void Start ()
    {
        player = FindObjectOfType<PlayerMotor>();
        monster = FindObjectOfType<Spector>();
        mainCamera = Camera.main;
        handleCanvas = FindObjectOfType<HandleCanvas>();
        thisPuzzleManager = FindObjectOfType<InvisibleFloorPuzzleManager>();

        if (this.gameObject.tag == "PullPlayer_Tile")
        {
            arms.SetActive(false);
        }
    }
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(this.gameObject.tag == "PullPlayer_Tile")
            {
                StartCoroutine(ArmPullResetAnim());
                //call player arm animation effect here
            }
            else if (this.gameObject.tag == "AlertMonster_Tile")
            {
                //Audio asset for noise of incorrect tile plays in this moment
                monster.AlertPosition = AlertPosition();
            }
        }
    }

    Vector3 AlertPosition()
    {
        alertedPos = player.transform.position;
        return alertedPos;
    }

    IEnumerator ArmPullResetAnim()
    {
        hasFinishedProcess = false;

        arms.SetActive(true);

        //call arms animtion
        mainCamera.GetComponent<Animator>().SetInteger("ArmsReset", 0);
        mainCamera.GetComponent<Animator>().SetInteger("ArmsPull", 1);
        handleCanvas.canUseButtons = false;

        yield return new WaitForSeconds(.5f);

        player.StopMovement();

        yield return new WaitForSeconds(.6f);

        //begin resetting arm animation to pull behind player
        mainCamera.GetComponent<Animator>().SetInteger("ArmsPull", 0);
        mainCamera.GetComponent<Animator>().SetInteger("ArmsReset", 1);

        yield return new WaitForSeconds(.2f);

        player.gameObject.layer = LayerMask.NameToLayer("Humanoid");

        yield return new WaitForSeconds(.3f);

        arms.SetActive(false);

        yield return new WaitForSeconds(.8f);

        player.gameObject.layer = LayerMask.NameToLayer("Default");
       
        player.ResetMoveSpeed();
        handleCanvas.canUseButtons = true;

        hasFinishedProcess = true;
        thisPuzzleManager.beginFogFollow = false;
        thisPuzzleManager.fogEffect.SetActive(false);
        thisPuzzleManager.hasFallen = true;
    }
}
