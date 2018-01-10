using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsanityManager : MonoBehaviour
{
    public Image insanityImg;
    private int currentInsanity = 0;
    public int CurrentInsanity
    {
        get { return currentInsanity; }
        set { currentInsanity = value; }
    }
    private int maxInsanity = 2;
    private int minInsanity = 0;
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
    private int pillStackMin = 0;
    private int pillStackMax = 3;

    private CameraMotor cameraMotor;
    private int sensitivityLvl;

    void Start()
    {
        insanityImg = GetComponentInChildren<Image>();
        cameraMotor = FindObjectOfType<CameraMotor>();
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
            else if (CurrentInsanity == 1)
            {
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
                        beginDraining = false;
                    }
                }
            }
            else if (CurrentInsanity == 2)
            {
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
                        beginDraining = false;
                    }
                }
            }
        }

    }

    public void AlterInsanity(int setInsanity)
    {
        beginDraining = true;
        CurrentInsanity += setInsanity;
        if (CurrentInsanity > maxInsanity)
        {
            CurrentInsanity = maxInsanity;
        }
        if (CurrentInsanity < minInsanity)
        {
            CurrentInsanity = minInsanity;
        }
        Debug.Log("current insanity: " + CurrentInsanity);
        currentTime = 100;
    }

    public void UpdatePillCount(int pill)
    {
        PillStackCount += pill;
        if (PillStackCount < pillStackMin)
        {
            PillStackCount = pillStackMin;
        }
        if(PillStackCount > pillStackMax)
        {
            PillStackCount = pillStackMax;
        }
        if(pill < 0 && CurrentInsanity > minInsanity)
        {
            AlterInsanity(-1); 
        }
        pillStackTxt.text = PillStackCount.ToString();
    }
}


