using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLoadScreen : MonoBehaviour
{
    public GameObject loadEffect;

	void Awake ()
    {
        StartCoroutine(OnStartLoadDelay());
	}
	
	IEnumerator OnStartLoadDelay()
    {
        loadEffect.SetActive(true);
        yield return new WaitForSeconds(1f);
        loadEffect.SetActive(false);
    }
}
