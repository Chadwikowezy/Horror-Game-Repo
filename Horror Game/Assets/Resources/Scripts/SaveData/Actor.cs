using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private CameraMotor camMotor;

    private OptionsManager optionsManager;

    private SceneLaunchManager sceneLaunchManager;

    void Start()
    {      
        if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Main Menu") &&
            SceneManager.GetActiveScene() != SceneManager.GetSceneByName("OpeningCutscene"))
        {
            insanityManager = FindObjectOfType<InsanityManager>();
            phoneManager = FindObjectOfType<PhoneManager>();

            phoneManager.RecievedCall();
            phoneManager.NewMessageNotification();
        }    
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Main Menu"))
        {
            sceneLaunchManager = FindObjectOfType<SceneLaunchManager>();
            sceneLaunchManager.RecievedCall();
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mansion"))
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

    public void ResetDataAttributes()
    {
        data.playerPos = Vector3.zero;
        data.firstRunThru = true;
        data.masionPuzzle_F1_01 = false;
        data.masionPuzzle_F1_02 = false;
        data.masionPuzzle_F1_03 = false;
        data.masionPuzzle_F2_01 = false;
        data.mausoleumPuzzle = false;
        data.cryptPuzzle = false;
        data.graveYardPuzzle = false;
        data.pillsCarried = 0;
        data.statueObjectsForPedestal.Clear();
        data.setMaxInsanity = 3;
        data.audioLevel = 3;
        data.lightLevel = 2;
        data.sensitivity = 2;
    }

    #region Store Data call
    public void StoreData()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Main Menu") &&
            SceneManager.GetActiveScene() != SceneManager.GetSceneByName("OpeningCutscene"))
        {
            data.firstRunThru = false;
            sectionManager = FindObjectOfType<SectionManager>();
            player = FindObjectOfType<PlayerMotor>();
            data.pillsCarried = insanityManager.PillStackCount;
            data.playerPos = player.GetComponent<Transform>().position;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mansion"))
        {
            MansionSectionManager();
            data.statueObjectsForPedestal.Clear();
            data.statueObjectsForPedestal.Add(toolManager.statueSequence01);
            data.statueObjectsForPedestal.Add(toolManager.statueSequence02);
            data.statueObjectsForPedestal.Add(toolManager.statueSequence03);
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Maze-Crypt"))
        {
            MazeSectionManager();
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Graveyard"))
        {
            GraveyardSectionManager();
        }
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
        optionsManager = FindObjectOfType<OptionsManager>();
        //setting audio involved
        if (data.audioLevel > 0)
        {
            optionsManager.audioLevel.value = data.audioLevel;
        }
        //setting light involved
        if (data.lightLevel > 0)
        {
            optionsManager.lightLevel.value = data.lightLevel;
            if (optionsManager.pointLights.Count > 0)
            {
                for (int i = 0; i < optionsManager.pointLights.Count; i++)
                {
                    optionsManager.pointLights[i].intensity = (data.lightLevel / 10f);
                }
            }

        }
        if (data.sensitivity > 0)
        {
            optionsManager.sensitivity.value = data.sensitivity;
        }

        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Main Menu") &&
           SceneManager.GetActiveScene() != SceneManager.GetSceneByName("OpeningCutscene"))
        {
            player = FindObjectOfType<PlayerMotor>();
            insanityManager = FindObjectOfType<InsanityManager>();
            sectionManager = FindObjectOfType<SectionManager>();
            camMotor = FindObjectOfType<CameraMotor>();
            //setting insanity involved         
            insanityManager.UpdatePillCount(data.pillsCarried);
            if (data.setMaxInsanity > 0)
            {
                insanityManager.maxInsanity = data.setMaxInsanity;
            }
            //setting sensitivity involved
            if (data.sensitivity > 0)
            {
                camMotor.sensitivityX = data.sensitivity;
                camMotor.sensitivityY = data.sensitivity;
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Maze-Crypt") &&
            data.masionPuzzle_F2_01 == true && data.mausoleumPuzzle == false)
        {
            if (data.mausoleumPuzzle == false)
            {
                data.playerPos = player.GetComponent<Transform>().position;
            }
            else
            {
                player.GetComponent<Transform>().position = data.playerPos;
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Mansion"))
        {
            toolManager = FindObjectOfType<ToolsManager>();
            LoadMansionSectionData();
            if (data.statueObjectsForPedestal.Count > 0)
            {
                toolManager.statueSequence01 = data.statueObjectsForPedestal[0];
                toolManager.statueSequence02 = data.statueObjectsForPedestal[1];
                toolManager.statueSequence03 = data.statueObjectsForPedestal[2];
            }
            if (data.firstRunThru == false)
            {
                player.GetComponent<Transform>().position = data.playerPos;
            }
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Maze-Crypt"))
        {
            LoadMazeSectionData();
        }
        else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Graveyard"))
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

    #region Load Maze Puzzle Sections Manager
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

    public int setMaxInsanity;
    public int audioLevel;
    public int lightLevel;
    public int sensitivity;
}
#endregion