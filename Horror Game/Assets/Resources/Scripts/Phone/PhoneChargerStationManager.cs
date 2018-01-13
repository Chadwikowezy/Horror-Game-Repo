using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneChargerStationManager : MonoBehaviour
{
    private PhoneManager phoneManager;
    private bool hasCompletedCharging = false;
    public GameObject phoneChargeButtonEvent;


    void Start ()
    {
        phoneManager = FindObjectOfType<PhoneManager>();	
	}

    void Update()
    {
        if(phoneManager.chargingPhone == true)
        {
            phoneManager.isOn = false;
            phoneManager.LookThruPhoneLens();
            phoneManager.messageObj.SetActive(false);
            phoneManager.phoneCameraUIObjs.SetActive(false);
            if (phoneManager.currentBatteryLife <= phoneManager.maxBatteryLife && phoneManager.currentBatteryLife >= phoneManager.minBatteryLife)
            {
                phoneManager.currentBatteryLife += Time.deltaTime * phoneManager.batteryDrainRate;
            }
            if (phoneManager.currentBatteryLife > phoneManager.maxBatteryLife)
            {
                phoneManager.currentBatteryLife = phoneManager.maxBatteryLife;
                hasCompletedCharging = true;
                phoneManager.chargingPhone = false;
                phoneManager.phoneCamera.SetActive(false);
                phoneManager.phoneCameraUIObjs.SetActive(true);

                if (hasCompletedCharging == true)
                {
                    phoneManager.phoneIsDead = false;
                    phoneManager.batteryChargingUI.SetActive(false);
                }
            }
            if (phoneManager.currentBatteryLife < phoneManager.minBatteryLife)
            {
                phoneManager.currentBatteryLife = phoneManager.minBatteryLife;
            }
        }     
    }        

    public void BeginCharging()
    {
        phoneManager.chargingPhone = true;
        phoneChargeButtonEvent.SetActive(false);
    }
}
