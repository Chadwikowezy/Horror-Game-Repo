using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    public bool isOn = false;
    public GameObject phoneCamera;

    public void LookThruPhoneLens()
    {
        if (isOn == false)
        {
            StartCoroutine(LookThruPhoneLensDelay());
        }
        else if(isOn == true)
        {
            StartCoroutine(DisablePhoneLensDelay());
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
