using System.Collections;
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
    public GameObject phoneDeadNotification;

    public bool chargingPhone = false;
    public GameObject batteryChargingUI;
    public Image chargingBatteryImg;


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
            Debug.Log("Should've enabled battery");
        }
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
        if(chargingPhone == true)
        {
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
        yield return new WaitForSeconds(1.25f);
        phoneCamera.SetActive(true);
        isOn = true;       
    }
    IEnumerator DisablePhoneLensDelay()
    {
        yield return new WaitForSeconds(.75f);
        phoneCamera.SetActive(false);
        isOn = false;      
    }
}
