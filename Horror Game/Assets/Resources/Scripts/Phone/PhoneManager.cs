﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    public bool isOn = false;
    public bool phoneIsDead = false;
    public GameObject phoneCamera;
    public GameObject phoneCameraUIObjs;

    public float maxBatteryLife = 60,
        minBatteryLife = 0, 
        batteryDrainRate = 1;
    public float currentBatteryLife;
    public Image phoneBattery;
    public GameObject phoneBatteryObj;
    public GameObject phoneDeadNotification;

    public bool chargingPhone = false;
    public GameObject batteryChargingUI;
    public Image chargingBatteryImg;

    public GameObject message_01;
    public GameObject message_02;
    public GameObject message_03;
    public GameObject message_04;
    public GameObject message_05;
    public GameObject message_06;
    public GameObject message_07;
    public GameObject messageObj;
    private bool messagesDisplayed = false;
    private Actor actor;

    private PlayerMotor playerMotor;

    public GameObject newMessageNotification;

    //public GameObject dummyPhone;
    public List<GameObject> playerDisableObjs;

    public void RecievedCall()
    {
        actor = FindObjectOfType<Actor>();
        playerMotor = FindObjectOfType<PlayerMotor>();
    }

    public void LookThruPhoneLens()
    {
        if(chargingPhone == false)
        {
            if (isOn == false && phoneIsDead == false)
            {
                StartCoroutine(LookThruPhoneLensDelay());
            }
            else if (isOn == true)
            {
                StartCoroutine(DisablePhoneLensDelay());
            }
            else if (phoneIsDead == true)
            {
                StartCoroutine(phoneDeadNotificationDelay());
            }
        }      
        else if(chargingPhone == true)
        {
            phoneCamera.SetActive(true);
            batteryChargingUI.SetActive(true);           
            //Debug.Log("Should've enabled battery");
        }
    }

    public void LookAtMessages()
    {
        if(chargingPhone == false)
        {
            if(isOn == false && phoneIsDead == false)
            {
                StartCoroutine(MessagesEnableDelay());
            }
            else if (isOn == true)
            {
                StartCoroutine(MessagesDisableDelay());
            }
            else if (phoneIsDead == true)
            {
                StartCoroutine(phoneDeadNotificationDelay());
            }
        }
    }

    IEnumerator MessagesEnableDelay()
    {
        isOn = true;
        playerMotor.onPhone = true;
        //dummyPhone.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        //dummyPhone.SetActive(true);
        for (int i = 0; i < playerDisableObjs.Count; i++)
        {
            playerDisableObjs[i].layer = LayerMask.NameToLayer("DisableFromView");
        }
        phoneCamera.SetActive(true);
        phoneCameraUIObjs.SetActive(false);
        messageObj.SetActive(true);
        if (actor.data.masionPuzzle_F1_01 == false || actor.data.firstRunThru == true)
        {
            message_01.SetActive(true);
        }
        if (actor.data.masionPuzzle_F1_01 == true)
        {
            message_01.SetActive(true);
            message_02.SetActive(true);
        }
        if (actor.data.masionPuzzle_F1_02 == true)
        {
            message_01.SetActive(true);
            message_02.SetActive(true);
            message_03.SetActive(true);
        }
        if (actor.data.masionPuzzle_F1_03 == true)
        {
            message_01.SetActive(true);
            message_02.SetActive(true);
            message_03.SetActive(true);
            message_04.SetActive(true);
        }
        if (actor.data.masionPuzzle_F2_01 == true)
        {
            message_01.SetActive(true);
            message_02.SetActive(true);
            message_03.SetActive(true);
            message_04.SetActive(true);
            message_05.SetActive(true);
        }
        if (actor.data.mausoleumPuzzle == true)
        {
            message_01.SetActive(true);
            message_02.SetActive(true);
            message_03.SetActive(true);
            message_04.SetActive(true);
            message_06.SetActive(true);
        }
        if (actor.data.cryptPuzzle == true)
        {
            message_01.SetActive(true);
            message_02.SetActive(true);
            message_03.SetActive(true);
            message_04.SetActive(true);
            message_06.SetActive(true);
            message_07.SetActive(true);
        }
        messagesDisplayed = true;
    }
    IEnumerator MessagesDisableDelay()
    {
        isOn = false;
        playerMotor.onPhone = false;
        yield return new WaitForSeconds(.75f);
        for (int i = 0; i < playerDisableObjs.Count; i++)
        {
            playerDisableObjs[i].layer = LayerMask.NameToLayer("Default");
        }
        //dummyPhone.SetActive(false);
        messageObj.SetActive(false);
        phoneCamera.SetActive(false);
        messagesDisplayed = false;
    }

    IEnumerator phoneDeadNotificationDelay()
    {
        phoneDeadNotification.SetActive(true);
        yield return new WaitForSeconds(3f);
        phoneDeadNotification.SetActive(false);
    }

    private void Update()
    {        
        if (isOn == true)
        {
            Camera.main.farClipPlane = 35;

            phoneBatteryObj.SetActive(true);
            if (currentBatteryLife <= maxBatteryLife && currentBatteryLife >= minBatteryLife)
            {
                currentBatteryLife -= Time.deltaTime * batteryDrainRate;
            }
            if (currentBatteryLife > maxBatteryLife)
            {
                currentBatteryLife = maxBatteryLife;
            }
            if (currentBatteryLife < minBatteryLife)
            {
                StartCoroutine(DisablePhoneLensDelay());
                phoneIsDead = true;                
                currentBatteryLife = minBatteryLife;
                phoneDeadNotificationDelay();
            }
            AlterBatteryLife(phoneBattery);
        }
        else if (isOn == false)
        {
            Camera.main.farClipPlane = 70;
        }
        if (chargingPhone == true)
        {
            phoneBatteryObj.SetActive(false);
            AlterBatteryLife(chargingBatteryImg);
        }
        
    }

    void AlterBatteryLife(Image batteryDisplay)
    {
        batteryDisplay.fillAmount = currentBatteryLife / maxBatteryLife;

        if (batteryDisplay.fillAmount < 1f && batteryDisplay.fillAmount > .75f)
        {
            batteryDisplay.color = Color.green;
        }
        if (batteryDisplay.fillAmount <= .66f)
        {
            batteryDisplay.color = Color.Lerp(Color.green, Color.yellow, 1f);
        }
        if (batteryDisplay.fillAmount <= .33f)
        {
            batteryDisplay.color = Color.Lerp(Color.yellow, Color.red, 1f);
        }
    }

    IEnumerator LookThruPhoneLensDelay()
    {
        isOn = true;
        playerMotor.onPhone = true;
        //dummyPhone.SetActive(true);
        yield return new WaitForSeconds(.01f);
        for (int i = 0; i < playerDisableObjs.Count; i++)
        {
            playerDisableObjs[i].layer = LayerMask.NameToLayer("DisableFromView");
        }
        messageObj.SetActive(false);
        phoneCameraUIObjs.SetActive(true);
        phoneCamera.SetActive(true);
    }
    IEnumerator DisablePhoneLensDelay()
    {
        phoneCamera.GetComponent<Animator>().Play("Phone_FlyOut");
        isOn = false;
        playerMotor.onPhone = false;
        yield return new WaitForSeconds(0.6f);
        for (int i = 0; i < playerDisableObjs.Count; i++)
        {
            playerDisableObjs[i].layer = LayerMask.NameToLayer("Default");
        }
        //dummyPhone.SetActive(false);
        phoneCamera.SetActive(false);
    }

    public void NewMessageNotification()
    {
        StartCoroutine(FlashNotification());
    }

    IEnumerator FlashNotification()
    {
        //player phone vibration sound effect
        for (int i = 0; i < 4; i++)
        {
            newMessageNotification.SetActive(true);
            yield return new WaitForSeconds(.5f);
            newMessageNotification.SetActive(false);
            yield return new WaitForSeconds(.5f);
        }
        newMessageNotification.SetActive(false);
    }
}
