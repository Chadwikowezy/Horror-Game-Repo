﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsManager : MonoBehaviour
{
    public bool barEmpty = true;

    public bool toolbar_01 = false;
    public bool toolbar_02 = false;
    public bool toolbar_03 = false;
    public bool toolbar_04 = false;

    public Image toolBar01, toolBar02, toolBar03, toolBar04;

    public int knightsStatue = 0;
    public int keys = 0;


    void Start ()
    {
        Image[] childrenOnToolbar = GetComponentsInChildren<Image>();

		if(barEmpty == true)
        {
            foreach(Image toolbarChild in childrenOnToolbar)
            {
                if(toolbarChild != this)
                {
                    //toolbarChild.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            foreach (Image toolbarChild in childrenOnToolbar)
            {
                //toolbarChild.gameObject.SetActive(true);
            }
        }
	}
}
