using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard_Gravestone : MonoBehaviour
{
    public Graveyard_CutsceneManager manager;
    public float detectionDistance;

    public GameObject collectButton;

    private void Start()
    {
        manager = FindObjectOfType<Graveyard_CutsceneManager>();
    }
    private void Update()
    {
        if ((manager.player.transform.position - transform.position).magnitude < detectionDistance)
            showCollectButton();
    }

    void showCollectButton()
    {
        //Play locket intro animation that transitions into examining animation
        //Set player "Stoped" property to true

        collectButton.SetActive(true);
    }
    public void collectObject()
    {
        //Play locket collect animation

        manager.monster.SetActive(true);
        //monster plays jump scare animation on activation
        //player plays jump back animation on monster activation
        //Set player "Stoped" property to false
    }
}
