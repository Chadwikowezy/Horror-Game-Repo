using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class OPCS_DoorController : MonoBehaviour
{
    private Animator anim;
    private OPCS_Player player;
    private OPCS_Camera cam;

    public enum doorStates { IDLE, OPEN, SLAMMED };
    public doorStates state = doorStates.IDLE;

	void Start ()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<OPCS_Player>();
        cam = FindObjectOfType<OPCS_Camera>();
    }

    public void PlayOpen()
    {
        state = doorStates.OPEN;
        anim.SetInteger("OpenDoor", 1);
        player.buttonEvent.SetActive(false);

        StartCoroutine(OpenDelay());
    }

    IEnumerator OpenDelay()
    {
        //play door creeking opening sound

        yield return new WaitForSeconds(2f);
        
        player.canPath = true;
        player.nextPathNode++;
        cam.rotSpeed = .1f;
        //footsteps start
        player.GetComponent<NavMeshAgent>().speed = 1;

        yield return new WaitForSeconds(2f);
        cam.target = cam.panRotTransforms[1].transform;
        //footsteps stop option1
        
        yield return new WaitForSeconds(2f);
        cam.target = cam.panRotTransforms[2].transform;
        //footsteps stop option2

        yield return new WaitForSeconds(2f);
        PlayerSlam();

        yield return new WaitForSeconds(.65f);
        //player door slam sound

        yield return new WaitForSeconds(.2f);
        cam.rotSpeed = .4f;
        cam.target = cam.panRotTransforms[3].transform;

        yield return new WaitForSeconds(3f);
        cam.rotSpeed = .3f;
        cam.target = cam.panRotTransforms[4].transform;

        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Mansion");
    }

    public void PlayerSlam()
    {
        state = doorStates.SLAMMED;
        anim.SetInteger("OpenDoor", 0);
        anim.SetInteger("SlamDoor", 1);      
    }
}
