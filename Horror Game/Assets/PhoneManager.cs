using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    public bool isOn = false;
    public bool phoneIsDead = false;
    public GameObject phoneCamera;

    private float maxBatteryLife = 60,
        minBatteryLife = 0, 
        batteryDrainRate = 1;
    public float currentBatteryLife;
    public Image phoneBattery;
    public GameObject phoneDeadNotification;

    public void LookThruPhoneLens()
    {
        if (isOn == false && phoneIsDead == false)
        {
            StartCoroutine(LookThruPhoneLensDelay());
        }
        else if(isOn == true)
        {
            StartCoroutine(DisablePhoneLensDelay());
        }
        else if(phoneIsDead == true)
        {
            StartCoroutine(phoneDeadNotificationDelay());
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

            phoneBattery.fillAmount = currentBatteryLife / maxBatteryLife;

            if(phoneBattery.fillAmount < 1f && phoneBattery.fillAmount > .75f)
            {
                phoneBattery.color = Color.green;
            }
            if(phoneBattery.fillAmount <= .66f)
            {
                phoneBattery.color = Color.Lerp(Color.green, Color.yellow, 1f);
            }
            if(phoneBattery.fillAmount <= .33f)
            {
                phoneBattery.color = Color.Lerp(Color.yellow, Color.red, 1f);
            }
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
