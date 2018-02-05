using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    #region variables
    private SectionManager sectionManager;
    private ToolsManager toolManager;
    private TilesPuzzleManager tilePuzzleManager;
    private GameObject toolParent;

    private GameController gameController;

    public enum tool { statue01, statue02, statue03, statue04, statue05, statue06, tile_01,
        tile_02, tile_03, tile_04, crowbar_01, key_01, key_02, button_01, button_02, button_03 };
    public tool toolType;

    private ToolCollect toolCollect;

    private PlayerMotor player;
    public Vector3 alertedPos;
    private Spector monster;

    private PhoneManager phoneManager;

    public GameObject fingerPrint;
    #endregion

    #region start
    private void Start()
    {
        toolCollect = FindObjectOfType<ToolCollect>();
        player = FindObjectOfType<PlayerMotor>();
        monster = FindObjectOfType<Spector>();
        sectionManager = FindObjectOfType<SectionManager>();
        toolManager = FindObjectOfType<ToolsManager>();
        phoneManager = FindObjectOfType<PhoneManager>();

        gameController = FindObjectOfType<GameController>();

        if(transform.tag == "Tool")
        {
            toolParent = GetComponent<GameObject>();
        }
        RemoveTools();
    }

    public void RemoveTools()
    {
        if (sectionManager.masionPuzzle_F1_01 == true)
        {
            if (toolType == tool.statue01)
            {
                Destroy(gameObject);
            }
            if (toolType == tool.statue02)
            {
                Destroy(gameObject);
            }
            if (toolType == tool.statue03)
            {
                Destroy(gameObject);
            }
            if (toolType == tool.statue04)
            {
                Destroy(gameObject);
            }
            if (toolType == tool.statue05)
            {
                Destroy(gameObject);
            }
            if (toolType == tool.statue06)
            {
                Destroy(gameObject);
            }
        }
        if (sectionManager.masionPuzzle_F1_02 == true)
        {
            if (toolType == tool.tile_01)
            {
                Destroy(gameObject);
            }
            if (toolType == tool.tile_02)
            {
                Destroy(gameObject);
            }
            if (toolType == tool.tile_03)
            {
                Destroy(gameObject);
            }
            if (toolType == tool.tile_04)
            {
                Destroy(gameObject);
            }
        }
        if (sectionManager.mausoleumPuzzle == true)
        {
            if (toolType == tool.key_01)
            {
                Destroy(gameObject);
            }
            if (toolType == tool.key_02)
            {
                Destroy(gameObject);
            }
            if (toolType == tool.crowbar_01)
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    #region OnTriggerEnter and OnTriggerExit function calls
    void IncorrectTilePressed()
    {
        toolManager.tilesValue = 0;
        toolManager.tileOneSequence = false;
        toolManager.tileTwoSequence = false;
        toolManager.tileThreeSequence = false;
        toolManager.tileFourSequence = false;

        //Audio asset for noise of incorrect tile plays in this moment
        monster.AlertPosition = AlertLocation();
        Debug.Log("Alerted position: " + AlertLocation() + "\nCurrent State: " + monster.CurrentState.ToString());
    }
    Vector3 AlertLocation()
    {
        alertedPos = player.transform.position;
        return alertedPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < 1; i++)
        {
            if (other.gameObject.tag == "Player")
            {
                if (gameObject.tag == "Tool")
                {
                    toolCollect.collectDisplay.SetActive(true);
                }
                #region Tile Specific information
                if (gameObject.tag == "Tile")
                {
                    if (GetComponent<Tools>().toolType == Tools.tool.tile_01)
                    {
                        if (toolManager.tileTwoSequence == false && toolManager.tileThreeSequence == false
                            && toolManager.tileFourSequence == false)
                        {
                            if(toolManager.tileOneSequence == false)
                            {
                                toolManager.tilesValue += 1;
                            }
                            toolManager.tileOneSequence = true;
                        }
                        else
                        {
                            IncorrectTilePressed();
                        }
                    }
                    else if (GetComponent<Tools>().toolType == Tools.tool.tile_02)
                    {
                        if (toolManager.tileOneSequence == true && toolManager.tileThreeSequence == false
                            && toolManager.tileFourSequence == false)
                        {
                            if(toolManager.tileTwoSequence == false)
                            {
                                toolManager.tilesValue += 1;
                            }
                            toolManager.tileTwoSequence = true;
                        }
                        else
                        {
                            IncorrectTilePressed();
                        }
                    }
                    else if (GetComponent<Tools>().toolType == Tools.tool.tile_03)
                    {
                        if (toolManager.tileOneSequence == true && toolManager.tileTwoSequence == true
                            && toolManager.tileFourSequence == false)
                        {
                            if(toolManager.tileThreeSequence == false)
                            {
                                toolManager.tilesValue += 1;
                            }
                            toolManager.tileThreeSequence = true;
                        }
                        else
                        {
                            IncorrectTilePressed();
                        }
                    }
                    else if (GetComponent<Tools>().toolType == Tools.tool.tile_04)
                    {
                        if (toolManager.tileOneSequence == true && toolManager.tileTwoSequence == true
                            && toolManager.tileThreeSequence == true)
                        {
                            if(toolManager.tileFourSequence == false)
                            {
                                toolManager.tilesValue += 1;
                            }
                            toolManager.tileFourSequence = true;
                            if (toolManager.tilesValue == 4)
                            {
                                tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();
                                if (tilePuzzleManager.sectionDoor == enabled)
                                {
                                    tilePuzzleManager.sectionDoor.SetActive(false);
                                }
                                SectionManager sectionManager = FindObjectOfType<SectionManager>();
                                sectionManager.masionPuzzle_F1_02 = true;
                                phoneManager.NewMessageNotification();
                                gameController.Save();

                                GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
                                for (int j = 0; j < tiles.Length; j++)
                                {
                                    if(tiles != null)
                                    {
                                        tiles[j].SetActive(false);
                                    }
                                }

                                tilePuzzleManager.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            IncorrectTilePressed();
                        }
                    }
                }
                #endregion
            }
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Tool")
            {
                toolCollect.collectDisplay.SetActive(false);
            }
        }
    }
    #endregion
}
