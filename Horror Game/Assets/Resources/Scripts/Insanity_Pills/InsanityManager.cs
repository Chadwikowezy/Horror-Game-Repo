using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InsanityManager : MonoBehaviour
{
    public Image insanityImg;
    public Image insanityBreakImg;
    private int currentInsanity = 0;
    public int CurrentInsanity
    {
        get { return currentInsanity; }
        set { currentInsanity = value; }
    }
    public int maxInsanity = 3;
    public int minInsanity = 0;
    private float fallRate = 5;
    public float currentTime;

    private bool beginDraining = false;

    public Text pillStackTxt;
    private int pillStackCount;
    public int PillStackCount
    {
        get { return pillStackCount; }
        set { pillStackCount = value; }
    }
    public int pillStackMin = 0;
    public int pillStackMax = 3;

    private CameraMotor cameraMotor;
    private HandleCanvas handleCanvas;
    private int sensitivityLvl;

    public bool justCollected = false;
    private Camera mainCamera;

    private AudioManager audioManager;

    public bool insanityBreakPlay = true;

    public UnityAds unityAds;

    void Start()
    {
        insanityImg = GetComponentInChildren<Image>();
        cameraMotor = FindObjectOfType<CameraMotor>();
        handleCanvas = FindObjectOfType<HandleCanvas>();
        mainCamera = Camera.main;
        //mainCamera.GetComponent<PostProcessingBehaviour>().profile.motionBlur.enabled = false;
        //mainCamera.GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = false;
        audioManager = FindObjectOfType<AudioManager>();
        if(unityAds == null)
        {
            unityAds = GetComponent<UnityAds>();
        }
    }

    void Update()
    {
        if (beginDraining == true)
        {
            if (CurrentInsanity == 0)
            {
                handleCanvas.canUseButtons = true;

                audioManager.breath_Heartbeat.volume = .5f;

                sensitivityLvl = 3;
                cameraMotor.sensitivityX = sensitivityLvl;
                cameraMotor.sensitivityY = sensitivityLvl;

                Color c = insanityImg.color;
                c.a = 1;
                if (currentTime > 0)
                {
                    currentTime -= fallRate * Time.deltaTime;
                    c.a = (currentTime / 100);
                    insanityImg.color = c;
                    if (currentTime <= 0)
                    {
                        insanityBreakPlay = true;
                        beginDraining = false;
                    }
                }
            }
            else if (CurrentInsanity == 1 && maxInsanity == 3)
            {
                handleCanvas.canUseButtons = true;

                audioManager.breath_Heartbeat.volume = .75f;

                sensitivityLvl = 4;
                cameraMotor.sensitivityX = sensitivityLvl;
                cameraMotor.sensitivityY = sensitivityLvl;

                Color c = insanityImg.color;
                c.a = 1;
                if (currentTime > 22)
                {
                    currentTime -= fallRate * Time.deltaTime;
                    c.a = (currentTime / 100);
                    insanityImg.color = c;
                    if (currentTime <= 22)
                    {
                        insanityBreakPlay = true;
                        beginDraining = false;
                    }
                }
            }
            else if (CurrentInsanity == 2 && maxInsanity == 3 || currentInsanity == 1 && maxInsanity == 2)
            {
                handleCanvas.canUseButtons = true;

                audioManager.breath_Heartbeat.volume = 1f;

                sensitivityLvl = 5;
                cameraMotor.sensitivityX = sensitivityLvl;
                cameraMotor.sensitivityY = sensitivityLvl;

                Color c = insanityImg.color;
                c.a = 1;
                if (currentTime > 44)
                {
                    currentTime -= fallRate * Time.deltaTime;
                    c.a = (currentTime / 100);
                    insanityImg.color = c;
                    if (currentTime <= 44)
                    {
                        insanityBreakPlay = true;
                        beginDraining = false;
                    }
                }
            }
            else if (currentInsanity == 3 && maxInsanity == 3 || currentInsanity == 1 && maxInsanity == 1 || currentInsanity == 2 && maxInsanity == 2)
            {
                handleCanvas.canUseButtons = false;

                if (insanityBreakPlay == true)
                {
                    audioManager.InsanityBreaking(1);
                    audioManager.breath_Heartbeat.volume = 1f;
                    insanityBreakPlay = false;
                }

                Color c = insanityBreakImg.color;
                c.a = 1;
                if (currentTime < 100)
                {
                    currentTime += (fallRate * 3) * Time.deltaTime;
                    c.a = (currentTime / 100);
                    insanityBreakImg.color = c;
                    if (currentTime >= 100)
                    {
                        unityAds.ShowAd();
                        int scene = SceneManager.GetActiveScene().buildIndex;
                        SceneManager.LoadScene(scene, LoadSceneMode.Single);
                    }
                }
            }
        }
    }

    //Chad call this function like so in monster-----> AlterInsanity(1)
    public void AlterInsanity(int setInsanity)
    {
        beginDraining = true;
        CurrentInsanity += setInsanity;
        currentTime = 100;
        if (CurrentInsanity >= maxInsanity)
        {
            CurrentInsanity = maxInsanity;
            currentTime = 0;
        }
        if (CurrentInsanity < minInsanity)
        {
            CurrentInsanity = minInsanity;
        }
        //Debug.Log("current insanity: " + CurrentInsanity);
    }

    public void UpdatePillData(int pill)
    {
        if (pill > 0 && PillStackCount < pillStackMax)
        {
            PillStackCount += pill;
        }
        pillStackTxt.text = PillStackCount.ToString();
    }

    public void UpdatePillCount(int pill)
    {
        //Debug.Log("Current before pill count: " + PillStackCount);
        if(currentInsanity < maxInsanity)
        {
            if (PillStackCount < pillStackMin)
            {
                PillStackCount = pillStackMin;
            }
            if (PillStackCount > pillStackMax)
            {
                PillStackCount = pillStackMax;
            }
            if (pill < 0 && CurrentInsanity > minInsanity && PillStackCount > 0)
            {
                PillStackCount += pill;
                AlterInsanity(-1);
                //play swallow sound
                audioManager.InsanityBreaking(0);
                //Debug.Log("Current after pill count: " + PillStackCount);
            }
            if (pill > 0 && PillStackCount < pillStackMax)
            {
                PillStackCount += pill;
                justCollected = true;
            }
            pillStackTxt.text = PillStackCount.ToString();
        }
        else
        {
            if (insanityBreakPlay == true)
            {
                audioManager.InsanityBreaking(1);
                audioManager.breath_Heartbeat.volume = 1f;
                insanityBreakPlay = false;
            }

            Color c = insanityBreakImg.color;
            c.a = 1;
            if (currentTime < 100)
            {
                currentTime += (fallRate * 3) * Time.deltaTime;
                c.a = (currentTime / 100);
                insanityBreakImg.color = c;
                if (currentTime >= 100)
                {
                    unityAds.ShowAd();
                    int scene = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(scene, LoadSceneMode.Single);
                }
            }
        }
    }
}


