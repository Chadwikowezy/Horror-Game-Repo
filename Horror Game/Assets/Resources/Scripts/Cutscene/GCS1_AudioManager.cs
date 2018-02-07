using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCS1_AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clip01, clip02, clip03, clip04, clip05;

    void Start ()
    {
        StartCoroutine(AudioDelay());
    }

    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(2f);
        audioSource.clip = clip01;
        //audioSource.Play();
    }
}
