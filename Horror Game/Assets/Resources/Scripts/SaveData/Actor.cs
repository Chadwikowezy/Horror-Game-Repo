﻿using System.Collections;
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
    private InsanityManager insanityManager;
    private PhoneManager phoneManager;
    private ToolsManager toolManager;

    void Start()
    {      
        insanityManager = FindObjectOfType<InsanityManager>();
        phoneManager = FindObjectOfType<PhoneManager>();
     
        phoneManager.RecievedCall();
        phoneManager.NewMessageNotification();

        if(Application.loadedLevel == 2)
        {
            MansionSceneStartCall();
        }
    }

    void MansionSceneStartCall()
    {
        statuePuzzleManager = FindObjectOfType<StatuePuzzleManager>();
        tilesPuzzleManager = FindObjectOfType<TilesPuzzleManager>();
        safePuzzleManager = FindObjectOfType<SafePuzzleManager>();
        toolManager = FindObjectOfType<ToolsManager>();

        statuePuzzleManager.RecievedCall();
        tilesPuzzleManager.RecievedCall();
        safePuzzleManager.RecievedCall();
    }
    #endregion

    #region Store Data call
    public void StoreData()
    {
        sectionManager = FindObjectOfType<SectionManager>();
        if (Application.loadedLevel == 2)
        {
            MansionSectionManager();
            data.statueObjectsForPedestal.Add(toolManager.statueSequence01);
            data.statueObjectsForPedestal.Add(toolManager.statueSequence02);
            data.statueObjectsForPedestal.Add(toolManager.statueSequence03);
        }
        else if (Application.loadedLevel == 3)
        {
            MazeSectionManager();
        }
        else if (Application.loadedLevel == 4)
        {
            GraveyardSectionManager();
        }

        player = FindObjectOfType<PlayerMotor>();
        data.pillsCarried = insanityManager.PillStackCount;
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
        if(sectionManager.mausoleumPuzzle == true)
        {
            data.mausoleumPuzzle = true;
        }
        if (sectionManager.cryptPuzzle == true)
        {
            data.cryptPuzzle = true;
        }     
    }
    #endregion

    #region Graveyard Puzzle Sections Manager
    void GraveyardSectionManager()
    {
        if(sectionManager.graveYardPuzzle == true)
        {
            data.graveYardPuzzle = true;
        }
    }
    #endregion

    #region Load Data call
    public void LoadData()
    {
        player = FindObjectOfType<PlayerMotor>();
        player.GetComponent<Transform>().position = data.playerPos;
        insanityManager = FindObjectOfType<InsanityManager>();

        sectionManager = FindObjectOfType<SectionManager>();
        insanityManager.UpdatePillCount(data.pillsCarried);

        if (Application.loadedLevel == 2)
        {
            toolManager = FindObjectOfType<ToolsManager>();
            LoadMansionSectionData();
            if(data.statueObjectsForPedestal.Count > 0)
            {
                toolManager.statueSequence01 = data.statueObjectsForPedestal[0];
                toolManager.statueSequence02 = data.statueObjectsForPedestal[1];
                toolManager.statueSequence03 = data.statueObjectsForPedestal[2];
            }
        }
        else if(Application.loadedLevel == 3)
        {
            LoadMazeSectionData();
        }
        else if (Application.loadedLevel == 4)
        {
            LoadGraveyardSectionData();
        }
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
        if (data.mausoleumPuzzle == true)
        {
            sectionManager.mausoleumPuzzle = true;
        }
        if (data.cryptPuzzle == true)
        {
            sectionManager.cryptPuzzle = true;
        }       
    }
    #endregion

    #region Load Graveyard Sections Manager
    void LoadGraveyardSectionData()
    {
        if(data.graveYardPuzzle == true)
        {
            sectionManager.graveYardPuzzle = true;
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
    //Main Menu scene
    public bool firstRunThru = true;

    public Vector3 playerPos;
    public bool masionPuzzle_F1_01 = false;
    public bool masionPuzzle_F1_02 = false;
    public bool masionPuzzle_F1_03 = false;
    public bool masionPuzzle_F2_01 = false;
    public bool mausoleumPuzzle = false;
    public bool cryptPuzzle = false;
    public bool graveYardPuzzle = false;

    public int pillsCarried;

    public List<int> statueObjectsForPedestal;
}
#endregion