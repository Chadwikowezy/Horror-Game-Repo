using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : TouchManager
{
    #region variables
    public enum type
    {        
        crouchButton, hideButton, pickupButton, sprintButton
    };
    public type buttonType;

    public Sprite crouchButtonSprite, hideButtonSprite, pickupButtonSprite, sprintButtonSprite;

    public GameObject playerObj = null;

    public GUITexture buttonTexture;

    public int isOn = 0;

    public GameObject playerAnimObj;
    private HandleCanvas handleCanvas;

    private CameraMotor cameraMotor;
    private PlayerMotor playerMotor;
    private float sensitivityReduction = .1f;

    public Transform dummyTest;

    //private AnimationManager animManager;

    #endregion

    #region start
    void Start()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.Find("Player");
        }
        handleCanvas = FindObjectOfType<HandleCanvas>();
        buttonTexture = GetComponent<GUITexture>();
        cameraMotor = FindObjectOfType<CameraMotor>();
        playerMotor = FindObjectOfType<PlayerMotor>();
    }
    #endregion

    #region update
    void Update()
    {
        TouchInput(buttonTexture);
    }
    #endregion

    #region assign sprites function
    public void AssignButtonSprites()
    {
        if (buttonType == type.crouchButton)
        {
            GetComponent<GUITexture>().texture = crouchButtonSprite.texture;
        }
        else if (buttonType == type.hideButton)
        {
            GetComponent<GUITexture>().texture = hideButtonSprite.texture;
        }
        else if (buttonType == type.pickupButton)
        {
            GetComponent<GUITexture>().texture = pickupButtonSprite.texture;
        }
        else if(buttonType == type.sprintButton)
        {
            GetComponent<GUITexture>().texture = sprintButtonSprite.texture;
        }
    }
    #endregion

    #region OnFirstTouch
    void OnFirstTouch()
    {
        if (handleCanvas.canUseButtons == true && handleCanvas.inAnimationState == false)
        {
            switch (buttonType)
            {
                case type.sprintButton:
                    //sprint
                    if (handleCanvas.movementJoytickStop == false && playerMotor.isGrounded == true)
                    {
                        if (playerObj.GetComponent<Rigidbody>().velocity.magnitude < 8)
                        {
                            playerMotor.isSprinting = true;
                            Vector3 dir = Camera.main.transform.TransformDirection(Vector3.forward);
                            dir.Set(dir.x, 0, dir.z);
                            playerObj.GetComponent<Rigidbody>().velocity = (dir * 7);
                            cameraMotor.sensitivityX = sensitivityReduction;
                            cameraMotor.sensitivityY = sensitivityReduction;
                        }
                    }
                    break;                
            }
            
        }
    }
    void OnSecondTouch()
    {
        if (handleCanvas.canUseButtons == true && handleCanvas.inAnimationState == false)
        {
            switch (buttonType)
            {
                case type.sprintButton:
                    //sprint
                    if (handleCanvas.movementJoytickStop == false && playerMotor.isGrounded == true)
                    {
                        if (playerObj.GetComponent<Rigidbody>().velocity.magnitude < 8)
                        {
                            playerMotor.isSprinting = true;
                            Vector3 dir = Camera.main.transform.TransformDirection(Vector3.forward);
                            dir.Set(dir.x, 0, dir.z);
                            playerObj.GetComponent<Rigidbody>().velocity = (dir * 7);
                            cameraMotor.sensitivityX = sensitivityReduction;
                            cameraMotor.sensitivityY = sensitivityReduction;
                        }
                    }                    
                    break;                   
            }
            
        }
    }
    #endregion

    #region isOnCounter
    void OnFirstTouchEnded()
    {
        isOn = 0;     
        if(playerMotor.isSprinting == true)
        {
            cameraMotor.sensitivityX = .6f;
            cameraMotor.sensitivityY = .6f;
            playerMotor.isSprinting = false;
        }
        
    }
    void OnSecondTouchEnded()
    {
        isOn = 0;     
        if (playerMotor.isSprinting == true)
        {
            cameraMotor.sensitivityX = .6f;
            cameraMotor.sensitivityY = .6f;
            playerMotor.isSprinting = false;
        }
        
    }

    IEnumerator ReturnToLookPos()
    {
        yield return new WaitForSeconds(.4f);
        playerObj.tag = "Player";
        playerMotor.moveSpeed = 5f;
        yield return new WaitForSeconds(.4f);
        cameraMotor.isAnimating = false;
    }
    #endregion
}