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
    private int sensitivityLvl;

    public bool justCollected = false;
    private Camera mainCamera;

    void Start()
    {
        insanityImg = GetComponentInChildren<Image>();
        cameraMotor = FindObjectOfType<CameraMotor>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (beginDraining == true)
        {
            if (CurrentInsanity == 0)
            {
                sensitivityLvl = 3;
                cameraMotor.sensitivityX = sensitivityLvl;
                cameraMotor.sensitivityY = sensitivityLvl;
                mainCamera.GetComponent<PostProcessingBehaviour>().profile.motionBlur.enabled = false;
                mainCamera.GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = false;

                Color c = insanityImg.color;
                c.a = 1;
                if (currentTime > 0)
                {
                    currentTime -= fallRate * Time.deltaTime;
                    c.a = (currentTime / 100);
                    insanityImg.color = c;
                    if (currentTime <= 0)
                    {
                        beginDraining = false;
                    }
                }
            }
            else if (CurrentInsanity == 1 && maxInsanity == 3)
            {
                sensitivityLvl = 4;
                cameraMotor.sensitivityX = sensitivityLvl;
                cameraMotor.sensitivityY = sensitivityLvl;
                mainCamera.GetComponent<PostProcessingBehaviour>().profile.motionBlur.enabled = true;
                mainCamera.GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = true;

                Color c = insanityImg.color;
                c.a = 1;
                if (currentTime > 22)
                {
                    currentTime -= fallRate * Time.deltaTime;
                    c.a = (currentTime / 100);
                    insanityImg.color = c;
                    if (currentTime <= 22)
                    {
                        beginDraining = false;
                    }
                }
            }
            else if (CurrentInsanity == 2 && maxInsanity == 3 || currentInsanity == 1 && maxInsanity == 2)
            {
                sensitivityLvl = 5;
                cameraMotor.sensitivityX = sensitivityLvl;
                cameraMotor.sensitivityY = sensitivityLvl;
                mainCamera.GetComponent<PostProcessingBehaviour>().profile.motionBlur.enabled = true;
                mainCamera.GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = true;

                Color c = insanityImg.color;
                c.a = 1;
                if (currentTime > 44)
                {
                    currentTime -= fallRate * Time.deltaTime;
                    c.a = (currentTime / 100);
                    insanityImg.color = c;
                    if (currentTime <= 44)
                    {
                        beginDraining = false;
                    }
                }
            }
            else if (currentInsanity == 3 && maxInsanity == 3 || currentInsanity == 1 && maxInsanity == 1 || currentInsanity == 2 && maxInsanity == 2)
            {
                Color c = insanityBreakImg.color;
                c.a = 1;
                if (currentTime < 100)
                {
                    currentTime += (fallRate * 3) * Time.deltaTime;
                    c.a = (currentTime / 100);
                    insanityBreakImg.color = c;
                    if (currentTime >= 100)
                    {
                        mainCamera.GetComponent<PostProcessingBehaviour>().profile.motionBlur.enabled = false;
                        mainCamera.GetComponent<PostProcessingBehaviour>().profile.depthOfField.enabled = false;
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

    public void UpdatePillCount(int pill)
    {
        //Debug.Log("Current before pill count: " + PillStackCount);
        if (PillStackCount < pillStackMin)
        {
            PillStackCount = pillStackMin;
        }
        if(PillStackCount > pillStackMax)
        {
            PillStackCount = pillStackMax;
        }
        if(pill < 0 && CurrentInsanity > minInsanity && PillStackCount > 0)
        {
            PillStackCount += pill;
            AlterInsanity(-1);
            //Debug.Log("Current after pill count: " + PillStackCount);
        }        
        if(pill > 0 && PillStackCount < pillStackMax)
        {
            PillStackCount += pill;
            justCollected = true;
        }
        pillStackTxt.text = PillStackCount.ToString();
    }
}


