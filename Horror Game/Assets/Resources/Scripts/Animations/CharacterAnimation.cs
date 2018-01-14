using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator playerAnimObj;
    private PlayerMotor playerMotor;
    
    private void Start()
    {
        playerAnimObj = GetComponent<Animator>();
        playerMotor = FindObjectOfType<PlayerMotor>();
    }
    private void Update()
    {
        AnimationManager();
    }

    void AnimationManager()
    {
        if(playerMotor.currentState == PlayerMotor.animStates.RUN)
        {
            playerAnimObj.SetInteger("Idle", 0);
            playerAnimObj.SetInteger("Walk", 0);
            playerAnimObj.SetInteger("Phone", 0);
            playerAnimObj.SetInteger("Run", 1);
        }
        else if(playerMotor.currentState == PlayerMotor.animStates.WALK)
        {
            playerAnimObj.SetInteger("Idle", 0);
            playerAnimObj.SetInteger("Phone", 0);
            playerAnimObj.SetInteger("Run", 0);
            playerAnimObj.SetInteger("Walk", 1);
        }
        else if(playerMotor.currentState == PlayerMotor.animStates.IDLE)
        {
            playerAnimObj.SetInteger("Phone", 0);
            playerAnimObj.SetInteger("Run", 0);
            playerAnimObj.SetInteger("Walk", 0);
            playerAnimObj.SetInteger("Idle", 1);
        }
        else if(playerMotor.currentState == PlayerMotor.animStates.HOLDPHONE)
        {
            playerAnimObj.SetInteger("Run", 0);
            playerAnimObj.SetInteger("Walk", 0);
            playerAnimObj.SetInteger("Idle", 0);
            playerAnimObj.SetInteger("Phone", 1);
        }
    }
}
