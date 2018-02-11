﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graveyard_CutsceneManager : MonoBehaviour
{
    public float fadeSpeed;
    public Image fadeOutScreen;
    public Canvas graveyardCanvas;

    public GameObject mausoleum;
    public GameObject largeTombstone;
    public GameObject player;
    public GameObject monster;

    private CutsceneCamera _cutsceneCamera;
    private CutscenePlayer _player;

    [Header("Audio Source")]
    public AudioSource audioSource_01, 
                       audioSource_02, 
                       audioSource_03,
                       audioSource_04, 
                       audioSource_05,
                       audioSource_06, 
                       audioSource_07,
                       audioSource_08, 
                       audioSource_09;

    private void Start()
    {
        _cutsceneCamera = FindObjectOfType<CutsceneCamera>();
        _player = player.GetComponent<CutscenePlayer>();

        StartCoroutine(fadeIntoScene());
        StartCoroutine(sceneIntro());
    }

    IEnumerator fadeIntoScene()
    {
        fadeOutScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        graveyardCanvas.sortingOrder = 2;

        while (fadeOutScreen.color.a > 0.1f)
        {
            fadeOutScreen.color = Color.Lerp(fadeOutScreen.color, Color.clear, fadeSpeed);

            yield return new WaitForFixedUpdate();
        }

        graveyardCanvas.sortingOrder = 0;

        fadeOutScreen.gameObject.SetActive(false);
    }
    IEnumerator sceneIntro()
    {
        audioSource_01.Play(); 
        _cutsceneCamera.lookTarget = mausoleum.transform;
        yield return new WaitForSeconds(2f);
        audioSource_02.Play(); 
        _cutsceneCamera.lookTarget = largeTombstone.transform;
        _player.enabled = true;

        audioSource_09.Play();

        yield return new WaitForSeconds(5f);
        _cutsceneCamera.lookTarget = null;
        
        yield return new WaitForSeconds(5f);
        audioSource_02.Stop();
        yield return new WaitForSeconds(2f);
        audioSource_02.Play();
        yield return new WaitForSeconds(7f);
        audioSource_02.Stop();
    }
    IEnumerator audioDelay()
    {
        audioSource_01.Stop();
        audioSource_03.Play();
        yield return new WaitForSeconds(2f);
        audioSource_04.Play();
        yield return new WaitForSeconds(1f);
        audioSource_05.Play();
        audioSource_06.Play();
        yield return new WaitForSeconds(8f);
        audioSource_06.Stop();
        audioSource_09.Stop();
        yield return new WaitForSeconds(1f);
        audioSource_08.Play();
    }

    public void OnClick()
    {
        StartCoroutine(audioDelay());
    }

}
