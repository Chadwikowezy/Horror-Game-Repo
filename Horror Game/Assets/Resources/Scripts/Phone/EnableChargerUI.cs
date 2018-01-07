using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableChargerUI : MonoBehaviour
{
    public GameObject phoneChargeButtonEvent;
    public PhoneManager phoneManager;

    void Start()
    {
        phoneManager = FindObjectOfType<PhoneManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            phoneManager.phoneCameraUIObjs.SetActive(false);
            phoneChargeButtonEvent.SetActive(true);
        }
    }	
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            phoneChargeButtonEvent.SetActive(false);
            phoneManager.chargingPhone = false;
            phoneManager.batteryChargingUI.SetActive(false);
            phoneManager.phoneCamera.SetActive(false);
            phoneManager.phoneCameraUIObjs.SetActive(true);
        }
    }
}
