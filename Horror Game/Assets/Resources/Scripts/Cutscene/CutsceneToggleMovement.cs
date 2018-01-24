using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneToggleMovement : MonoBehaviour
{
    public GameObject player;
    public float triggerDistance;
    public float waitTime;
    public bool stopIndefinitely;

    private void Update()
    {
        if ((transform.position - player.transform.position).magnitude < triggerDistance)
        {
            if (stopIndefinitely)
            {
                player.GetComponent<CutscenePlayer>().Stoped = true;
                enabled = false;
            }
            else
                StartCoroutine(wait(waitTime));
        }
    }

    IEnumerator wait(float _waitTime)
    {
        player.GetComponent<CutscenePlayer>().Stoped = true;

        yield return new WaitForSeconds(_waitTime);

        player.GetComponent<CutscenePlayer>().Stoped = false;
        enabled = false;
    }
}
