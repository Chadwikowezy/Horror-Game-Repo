using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    private Camera cam;
    public bool isOn = false;
    public GameObject[] numbers;
    public GameObject topBanner;
    public GameObject bottomBanner;

    void Start ()
    {
        cam = Camera.main;
    }

    public void LookThruPhoneLens()
    {
        numbers = GameObject.FindGameObjectsWithTag("Number");
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
        foreach(GameObject number in numbers)
        {
            number.layer = LayerMask.NameToLayer("Default");
            topBanner.SetActive(true);
            bottomBanner.SetActive(true);
            isOn = true;
        }
    }
    IEnumerator DisablePhoneLensDelay()
    {
        yield return new WaitForSeconds(.75f);
        foreach (GameObject number in numbers)
        {
            number.layer = LayerMask.NameToLayer("Number");
            topBanner.SetActive(false);
            bottomBanner.SetActive(false);
            isOn = false;
        }
    }
}
