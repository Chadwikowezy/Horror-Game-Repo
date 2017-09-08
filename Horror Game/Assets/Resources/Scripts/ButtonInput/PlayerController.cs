using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TouchManager
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

    public CameraMotor cameraMotor;
    private float sensitivityReduction = .1f;

    public Transform dummyTest;

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
                    //crouch animation, waiting for arms 
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
                    //crouch animation, waiting for arms 
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
                    if (handleCanvas.movementJoytickStop == false)
                    {
                        if (playerObj.GetComponent<Rigidbody>().velocity.magnitude < 8)
                        {
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
                    if (handleCanvas.movementJoytickStop == false)
                    {
                        if (playerObj.GetComponent<Rigidbody>().velocity.magnitude < 8)
                        {
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
        cameraMotor.sensitivityX = .6f;
        cameraMotor.sensitivityY = .6f;
    }
    void OnSecondTouchEnded()
    {
        isOn = 0;
        cameraMotor.sensitivityX = .6f;
        cameraMotor.sensitivityY = .6f;
    }
    #endregion
}