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

    void Start()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.Find("Player");
        }
        handleCanvas = FindObjectOfType<HandleCanvas>();
        buttonTexture = GetComponent<GUITexture>();
        cameraMotor = FindObjectOfType<CameraMotor>();
        //animManager = FindObjectOfType<AnimationManager>();
        playerMotor = FindObjectOfType<PlayerMotor>();
    }

    void Update()
    {
        TouchInput(buttonTexture);
    }

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

    #region OnFirst and OnSecond touch began
    void OnFirstTouchBegan()
    {
        if (handleCanvas.canUseButtons == true && handleCanvas.inAnimationState == false)
        {
            switch (buttonType)
            {
                case type.crouchButton:
                    if (playerMotor.isSprinting == false && playerMotor.isCrouching == false)
                    {
                        playerMotor.isCrouching = true;
                        playerMotor.moveSpeed = 2.5f;
                        //animManager.SetAnimState("crouch");
                        playerObj.tag = "Player_Crouched";
                        cameraMotor.isAnimating = true;
                    }
                    else if(playerMotor.isCrouching == true)
                    {
                        StartCoroutine(ReturnToLookPos());
                    }
                    break;
            }
            switch (buttonType)
            {
                case type.hideButton:
                    //hide logic
                    break;
            }
            switch (buttonType)
            {
                case type.pickupButton:
                    //pickup item
                    break;
            }           
        }
    }
    void OnSecondTouchBegan()
    {
        if (handleCanvas.canUseButtons == true && handleCanvas.inAnimationState == false)
        {
            switch (buttonType)
            {
                case type.crouchButton:
                    if (playerMotor.isSprinting == false && playerMotor.isCrouching == false)
                    {
                        playerMotor.isCrouching = true;
                        playerMotor.moveSpeed = 2.5f;
                        //animManager.SetAnimState("crouch");
                        playerObj.tag = "Player_Crouched";
                        cameraMotor.isAnimating = true;
                    }
                    else if (playerMotor.isCrouching == true)
                    {
                        StartCoroutine(ReturnToLookPos());
                    }
                    break;
            }
            switch (buttonType)
            {
                case type.hideButton:
                    //hide logic
                    break;
            }
            switch (buttonType)
            {
                case type.pickupButton:
                    //pickup item
                    break;
            }           
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
                    if (handleCanvas.movementJoytickStop == false && playerMotor.isCrouching == false)
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
                    if (handleCanvas.movementJoytickStop == false && playerMotor.isCrouching == false)
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
        playerMotor.isCrouching = false;
        //animManager.SetAnimState("idle");
        playerObj.tag = "Player";
        playerMotor.moveSpeed = 5f;
        yield return new WaitForSeconds(.4f);
        cameraMotor.isAnimating = false;
    }
    #endregion
}