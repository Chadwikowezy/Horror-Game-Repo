using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : TouchManager
{
    #region variables
    public enum type
    {        
        crouchButton, hideButton, pickupButton
    };
    public type buttonType;

    public Sprite crouchButtonSprite, hideButtonSprite, pickupButtonSprite;

    public GameObject playerObj = null;

    public GUITexture buttonTexture;

    public int isOn = 0;

    public GameObject playerAnimObj;
    private HandleCanvas handleCanvas;

    #endregion

    void Start()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.Find("Player");
        }
        handleCanvas = FindObjectOfType<HandleCanvas>();
        buttonTexture = GetComponent<GUITexture>();
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
                    //crouch
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
                    playerObj.transform.localScale = new Vector3(playerObj.transform.localPosition.x, .5f);
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
            //switch (buttonType)
        }
    }
    void OnSecondTouch()
    {
        if (handleCanvas.canUseButtons == true && handleCanvas.inAnimationState == false)
        {
            //switch (buttonType)
        }
    }
    #endregion

    #region isOnCounter
    void OnFirstTouchEnded()
    {
        isOn = 0;
    }
    void OnSecondTouchEnded()
    {
        isOn = 0;
    }
    #endregion
}