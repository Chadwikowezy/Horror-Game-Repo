using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Graveyard_Gravestone : MonoBehaviour
{
    public Graveyard_CutsceneManager manager;
    public float detectionDistance;

    public GameObject collectButton;
    public GameObject locket;
    public GameObject[] secondHalfWaypoints;

    private bool collected;

    private void Start()
    {
        manager = FindObjectOfType<Graveyard_CutsceneManager>();
    }
    private void Update()
    {
        if ((manager.player.transform.position - transform.position).magnitude < detectionDistance && !collected)
            showCollectButton();
    }

    void showCollectButton()
    {
        locket.GetComponent<Animator>().enabled = true;
        manager.player.GetComponent<CutscenePlayer>().Stoped = true;

        collectButton.SetActive(true);
    }
    public void collectObject()
    {
        CutscenePlayer playerScript = manager.player.GetComponent<CutscenePlayer>();
        CutsceneCamera cam = FindObjectOfType<CutsceneCamera>();

        foreach (GameObject waypoint in secondHalfWaypoints)
            waypoint.SetActive(true);

        cam.lookTarget = transform;
        collected = true;
        Destroy(locket);
        manager.monster.SetActive(true);
        playerScript.Stoped = false;
        playerScript.knockBack(manager.player.transform.TransformPoint(-manager.player.transform.forward), 5);
        collectButton.SetActive(false);
    }
}
