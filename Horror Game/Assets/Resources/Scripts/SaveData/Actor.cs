using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class Actor : MonoBehaviour
{
    public ActorData data;
    private SectionManager sectionManager;

	void Start ()
    {
		
	}
	
	public void StoreData()
    {
        sectionManager = FindObjectOfType<SectionManager>();
        MansionSectionManager();
        MazeSectionManager();
    }

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
        if (sectionManager.masionPuzzle_F2_02 == true)
        {
            data.masionPuzzle_F2_02 = true;
        }
        if (sectionManager.masionPuzzle_F2_03 == true)
        {
            data.masionPuzzle_F2_03 = true;
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

    public void LoadData()
    {
        sectionManager = FindObjectOfType<SectionManager>();
        LoadMansionSectionData();
        LoadMazeSectionData();
    }

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
        if (data.masionPuzzle_F2_02 == true)
        {
            sectionManager.masionPuzzle_F2_02 = true;
        }
        if (data.masionPuzzle_F2_03 == true)
        {
            sectionManager.masionPuzzle_F2_03 = true;
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
    public bool masionPuzzle_F1_01 = false;
    public bool masionPuzzle_F1_02 = false;
    public bool masionPuzzle_F1_03 = false;
    public bool masionPuzzle_F2_01 = false;
    public bool masionPuzzle_F2_02 = false;
    public bool masionPuzzle_F2_03 = false;
    public bool mazePuzzle_01 = false;
    public bool mazePuzzle_02 = false;
    public bool mazePuzzle_03 = false;
    public bool mazePuzzle_04 = false;
}
#endregion