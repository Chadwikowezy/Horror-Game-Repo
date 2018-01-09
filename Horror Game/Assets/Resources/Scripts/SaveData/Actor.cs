using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class Actor : MonoBehaviour
{
    #region variables & start
    public ActorData data;
    private SectionManager sectionManager;
    private PlayerMotor player;

    private StatuePuzzleManager statuePuzzleManager;
    private SafePuzzleManager safePuzzleManager;
    private TilesPuzzleManager tilesPuzzleManager;
    private InvisibleFloorPuzzleManager invisibleFloorPuzzleManager;

    void Start()
    {
        statuePuzzleManager = FindObjectOfType<StatuePuzzleManager>();
        tilesPuzzleManager = FindObjectOfType<TilesPuzzleManager>();
        safePuzzleManager = FindObjectOfType<SafePuzzleManager>();

        if (data.firstRunThru == true)
        {
            statuePuzzleManager.RecievedCall();
            tilesPuzzleManager.RecievedCall();
            safePuzzleManager.RecievedCall();
        }
    }
    #endregion

    #region Store Data call
    public void StoreData()
    {
        player = FindObjectOfType<PlayerMotor>(); 
        sectionManager = FindObjectOfType<SectionManager>();
        MansionSectionManager();
        MazeSectionManager();
        data.playerPos = player.GetComponent<Transform>().position;
        data.firstRunThru = false;
    }
    #endregion

    #region Mansion Puzzle Sections Manager
    void MansionSectionManager()
    {
        if (sectionManager.masionPuzzle_F1_01 == true)
        {
            data.masionPuzzle_F1_01 = true;
        }
        if (sectionManager.masionPuzzle_F1_02 == true)
        {
            data.masionPuzzle_F1_02 = true;
        }
        if (sectionManager.masionPuzzle_F1_03 == true)
        {
            data.masionPuzzle_F1_03 = true;
        }
        if (sectionManager.masionPuzzle_F2_01 == true)
        {
            data.masionPuzzle_F2_01 = true;
        }
    }
    #endregion

    #region Maze & Mausoleum Puzzle Sections Manager
    void MazeSectionManager()
    {
        if(sectionManager.mazePuzzle_01 == true)
        {
            data.mazePuzzle_01 = true;
        }
        if (sectionManager.mazePuzzle_02 == true)
        {
            data.mazePuzzle_02 = true;
        }
        if (sectionManager.mazePuzzle_03 == true)
        {
            data.mazePuzzle_03 = true;
        }
        if (sectionManager.mazePuzzle_04 == true)
        {
            data.mazePuzzle_04 = true;
        }
    }
    #endregion

    #region Load Data call
    public void LoadData()
    {
        player = FindObjectOfType<PlayerMotor>();
        player.GetComponent<Transform>().position = data.playerPos;

        data.firstRunThru = false;
        sectionManager = FindObjectOfType<SectionManager>();
        LoadMansionSectionData();
        LoadMazeSectionData();
    }
    #endregion

    #region Load Mansion Puzzle Sections Manager
    void LoadMansionSectionData()
    {
        if (data.masionPuzzle_F1_01 == true)
        {
            sectionManager.masionPuzzle_F1_01 = true;
        }
        if (data.masionPuzzle_F1_02 == true)
        {
            sectionManager.masionPuzzle_F1_02 = true;
        }
        if (data.masionPuzzle_F1_03 == true)
        {
            sectionManager.masionPuzzle_F1_03 = true;
        }
        if (data.masionPuzzle_F2_01 == true)
        {
            sectionManager.masionPuzzle_F2_01 = true;
        }
    }
    #endregion

    #region Load Mansion Puzzle Sections Manager
    void LoadMazeSectionData()
    {
        if (data.mazePuzzle_01 == true)
        {
            sectionManager.mazePuzzle_01 = true;
        }
        if (data.mazePuzzle_02 == true)
        {
            sectionManager.mazePuzzle_02 = true;
        }
        if (data.mazePuzzle_03 == true)
        {
            sectionManager.mazePuzzle_03 = true;
        }
        if (data.mazePuzzle_04 == true)
        {
            sectionManager.mazePuzzle_04 = true;
        }
    }
    #endregion

    #region Applying Save Data Methodology
    public void ApplyData()
    {
        SaveData.AddActorData(data);
    }
    void OnEnable()
    {
        SaveData.OnLoaded += LoadData;
        SaveData.OnBeforeSave += StoreData;
        SaveData.OnBeforeSave += ApplyData;
    }
    void OnDisable()
    {
        SaveData.OnLoaded -= LoadData;
        SaveData.OnBeforeSave -= StoreData;
        SaveData.OnBeforeSave -= ApplyData;
    }
    #endregion
}

#region ActorData Class
[Serializable]
public class ActorData
{
    public Vector3 playerPos;
    public bool masionPuzzle_F1_01 = false;
    public bool masionPuzzle_F1_02 = false;
    public bool masionPuzzle_F1_03 = false;
    public bool masionPuzzle_F2_01 = false;
    public bool mazePuzzle_01 = false;
    public bool mazePuzzle_02 = false;
    public bool mazePuzzle_03 = false;
    public bool mazePuzzle_04 = false;

    public bool firstRunThru = true;
    public bool isOutside = false;
}
#endregion