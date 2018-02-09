﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolCollect : MonoBehaviour
{
    #region variables
    public List<Tools> sectionOneTools = new List<Tools>();

    public List<Tools> mausoleumTools = new List<Tools>();

    private PlayerMotor player;
    private ToolsManager toolManager;

    public GameObject collectDisplay;

    private bool pickedUp;

    private GameController gameController;

    private TilesPuzzleManager tilePuzzleManager;

    public bool slotOneFilled = false;
    public bool slotTwoFilled = false;
    public bool slotThreeFilled = false;

    public int correctSequence = 0;

    public Sprite
        abstractArt_01,
        abstractArt_02,
        abstractArt_03,
        abstractArt_04,
        abstractArt_05,
        abstractArt_06, 
        key,
        crowbar;
    #endregion

    #region Start
    void Start()
    {
        player = FindObjectOfType<PlayerMotor>();
        toolManager = FindObjectOfType<ToolsManager>();
        gameController = FindObjectOfType<GameController>();
    }
    #endregion

    void EnableAlpha(Image img)
    {
        Color c = img.color;
        c.a = 1;
        img.color = c;
    }

    #region Assign Toolbar image sprites
    public void AssignToolSprite(Tools tool)
    {
        toolManager = FindObjectOfType<ToolsManager>();

        if (tool.toolType == Tools.tool.statue01)
        {
            if(slotOneFilled == false)
            {
                EnableAlpha(toolManager.toolBar01);
                toolManager.toolBar01.sprite = abstractArt_01;
                slotOneFilled = true;
            }
            else if(slotOneFilled == true && slotTwoFilled == false)
            {
                EnableAlpha(toolManager.toolBar02);
                toolManager.toolBar02.sprite = abstractArt_01;
                slotTwoFilled = true;
            }
            else if(slotOneFilled == true && slotTwoFilled == true && slotThreeFilled == false)
            {
                EnableAlpha(toolManager.toolBar03);
                toolManager.toolBar03.sprite = abstractArt_01;
                slotThreeFilled = true;
            }
        }
        else if (tool.toolType == Tools.tool.statue02)
        {
            if (slotOneFilled == false)
            {
                EnableAlpha(toolManager.toolBar01);
                toolManager.toolBar01.sprite = abstractArt_02;
                slotOneFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == false)
            {
                EnableAlpha(toolManager.toolBar02);
                toolManager.toolBar02.sprite = abstractArt_02;
                slotTwoFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == true && slotThreeFilled == false)
            {
                EnableAlpha(toolManager.toolBar03);
                toolManager.toolBar03.sprite = abstractArt_02;
                slotThreeFilled = true;
            }
        }
        else if (tool.toolType == Tools.tool.statue03)
        {
            if (slotOneFilled == false)
            {
                EnableAlpha(toolManager.toolBar01);
                toolManager.toolBar01.sprite = abstractArt_03;
                slotOneFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == false)
            {
                EnableAlpha(toolManager.toolBar02);
                toolManager.toolBar02.sprite = abstractArt_03;
                slotTwoFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == true && slotThreeFilled == false)
            {
                EnableAlpha(toolManager.toolBar03);
                toolManager.toolBar03.sprite = abstractArt_03;
                slotThreeFilled = true;
            }
        }
        else if (tool.toolType == Tools.tool.statue04)
        {
            if (slotOneFilled == false)
            {
                EnableAlpha(toolManager.toolBar01);
                toolManager.toolBar01.sprite = abstractArt_04;
                slotOneFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == false)
            {
                EnableAlpha(toolManager.toolBar02);
                toolManager.toolBar02.sprite = abstractArt_04;
                slotTwoFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == true && slotThreeFilled == false)
            {
                EnableAlpha(toolManager.toolBar03);
                toolManager.toolBar03.sprite = abstractArt_04;
                slotThreeFilled = true;
            }
        }
        else if (tool.toolType == Tools.tool.statue05)
        {
            if (slotOneFilled == false)
            {
                EnableAlpha(toolManager.toolBar01);
                toolManager.toolBar01.sprite = abstractArt_05;
                slotOneFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == false)
            {
                EnableAlpha(toolManager.toolBar02);
                toolManager.toolBar02.sprite = abstractArt_05;
                slotTwoFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == true && slotThreeFilled == false)
            {
                EnableAlpha(toolManager.toolBar03);
                toolManager.toolBar03.sprite = abstractArt_05;
                slotThreeFilled = true;
            }
        }
        else if (tool.toolType == Tools.tool.statue06)
        {
            if (slotOneFilled == false)
            {
                EnableAlpha(toolManager.toolBar01);
                toolManager.toolBar01.sprite = abstractArt_06;
                slotOneFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == false)
            {
                EnableAlpha(toolManager.toolBar02);
                toolManager.toolBar02.sprite = abstractArt_06;
                slotTwoFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == true && slotThreeFilled == false)
            {
                EnableAlpha(toolManager.toolBar03);
                toolManager.toolBar03.sprite = abstractArt_06;
                slotThreeFilled = true;
            }
        }
        else if (tool.toolType == Tools.tool.key_01)
        {
            if (slotOneFilled == false)
            {
                toolManager.toolBar01.sprite = key;
                slotOneFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == false)
            {
                toolManager.toolBar02.sprite = key;
                slotTwoFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == true && slotThreeFilled == false)
            {
                toolManager.toolBar03.sprite = key;
                slotThreeFilled = true;
            }
        }
        else if (tool.toolType == Tools.tool.key_02)
        {
            if (slotOneFilled == false)
            {
                toolManager.toolBar01.sprite = key;
                slotOneFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == false)
            {
                toolManager.toolBar02.sprite = key;
                slotTwoFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == true && slotThreeFilled == false)
            {
                toolManager.toolBar03.sprite = key;
                slotThreeFilled = true;
            }
        }
        else if (tool.toolType == Tools.tool.crowbar_01)
        {
            if (slotOneFilled == false)
            {
                toolManager.toolBar01.sprite = crowbar;
                slotOneFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == false)
            {
                toolManager.toolBar02.sprite = crowbar;
                slotTwoFilled = true;
            }
            else if (slotOneFilled == true && slotTwoFilled == true && slotThreeFilled == false)
            {
                toolManager.toolBar03.sprite = crowbar;
                slotThreeFilled = true;
            }
        }
    }
    #endregion

    #region Collect Tool function call
    public void CollectTool()
    {
        if(toolManager.statuesCollected < 3)
        {
            foreach (Tools tool in sectionOneTools)
            {
                if (tool != null)
                {
                    if (Vector3.Distance(player.transform.position, tool.gameObject.transform.position) <= 2f)
                    {
                        if (tool.GetComponent<Tools>().toolType == Tools.tool.statue01)
                        {
                            toolManager.statuesCollected += 1;
                            AssignToolSprite(tool);
                            if(toolManager.statueSequence01 == 1 || toolManager.statueSequence02 == 1 || toolManager.statueSequence03 == 1)
                            {
                                correctSequence++;
                            }
                            tool.gameObject.SetActive(false);
                            pickedUp = true;
                            collectDisplay.SetActive(false);
                        }
                        if (tool.GetComponent<Tools>().toolType == Tools.tool.statue02)
                        {
                            toolManager.statuesCollected += 1;
                            AssignToolSprite(tool);
                            if (toolManager.statueSequence01 == 2 || toolManager.statueSequence02 == 2 || toolManager.statueSequence03 == 2)
                            {
                                correctSequence++;
                            }
                            tool.gameObject.SetActive(false);
                            pickedUp = true;
                            collectDisplay.SetActive(false);
                        }
                        if (tool.GetComponent<Tools>().toolType == Tools.tool.statue03)
                        {
                            toolManager.statuesCollected += 1;
                            AssignToolSprite(tool);
                            if (toolManager.statueSequence01 == 3 || toolManager.statueSequence02 == 3 || toolManager.statueSequence03 == 3)
                            {
                                correctSequence++;
                            }
                            tool.gameObject.SetActive(false);
                            pickedUp = true;
                            collectDisplay.SetActive(false);
                        }
                        if (tool.GetComponent<Tools>().toolType == Tools.tool.statue04)
                        {
                            toolManager.statuesCollected += 1;
                            AssignToolSprite(tool);
                            if (toolManager.statueSequence01 == 4 || toolManager.statueSequence02 == 4 || toolManager.statueSequence03 == 4)
                            {
                                correctSequence++;
                            }
                            tool.gameObject.SetActive(false);
                            pickedUp = true;
                            collectDisplay.SetActive(false);
                        }
                        if (tool.GetComponent<Tools>().toolType == Tools.tool.statue05)
                        {
                            toolManager.statuesCollected += 1;
                            AssignToolSprite(tool);
                            if (toolManager.statueSequence01 == 5 || toolManager.statueSequence02 == 5 || toolManager.statueSequence03 == 5)
                            {
                                correctSequence++;
                            }
                            tool.gameObject.SetActive(false);
                            pickedUp = true;
                            collectDisplay.SetActive(false);
                        }
                        if (tool.GetComponent<Tools>().toolType == Tools.tool.statue06)
                        {
                            toolManager.statuesCollected += 1;
                            AssignToolSprite(tool);
                            if (toolManager.statueSequence01 == 6 || toolManager.statueSequence02 == 6 || toolManager.statueSequence03 == 6)
                            {
                                correctSequence++;
                            }
                            tool.gameObject.SetActive(false);
                            pickedUp = true;
                            collectDisplay.SetActive(false);
                        }
                    }
                    if(correctSequence == 3)
                    {
                        toolManager.correctStatueSequence = true;
                    }
                    else
                    {
                        toolManager.correctStatueSequence = false;
                    }
                }
            }           
        }
        //gameController.Save();
    }
    #endregion

    public void CollectMausoleumObjects()
    {     
        foreach (Tools tool in mausoleumTools)
        {
            if (tool != null)
            {
                //Debug.Log("Blah");
                if (Vector3.Distance(player.transform.position, tool.gameObject.transform.position) <= 7f)
                {
                    if (tool.GetComponent<Tools>().toolType == Tools.tool.key_01)
                    {
                        toolManager.keysCollected += 1;
                        AssignToolSprite(tool);
                        tool.gameObject.SetActive(false);
                        collectDisplay.SetActive(false);
                    }
                    if (tool.GetComponent<Tools>().toolType == Tools.tool.key_02)
                    {
                        toolManager.keysCollected += 1;
                        AssignToolSprite(tool);
                        tool.gameObject.SetActive(false);
                        collectDisplay.SetActive(false);
                    }
                    if (tool.GetComponent<Tools>().toolType == Tools.tool.crowbar_01)
                    {
                        toolManager.hasCrowbar = true;
                        AssignToolSprite(tool);
                        tool.gameObject.SetActive(false);
                        collectDisplay.SetActive(false);
                    }
                }
            }
        }
    }
}
