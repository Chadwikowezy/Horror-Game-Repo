using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsManager : MonoBehaviour
{
    #region variables
    public bool barEmpty = true;

    public bool toolbar_01 = false;
    public bool toolbar_02 = false;
    public bool toolbar_03 = false;
    public bool toolbar_04 = false;

    public Image toolBar01, toolBar02, toolBar03, toolBar04;

    [Header("Statues related")]
    public int statuesCollected = 0;
    public bool correctStatueSequence;
    public int statueSequence01, statueSequence02, statueSequence03;

    [Header("Mansion Tiles related")]
    public int tilesValue = 0;
    public bool tileOneSequence;
    public bool tileTwoSequence;
    public bool tileThreeSequence;
    public bool tileFourSequence;

    [Header("Maze-Crypt related")]
    public int keys = 0;
    public bool hasCrowbar = false;
    #endregion
}
