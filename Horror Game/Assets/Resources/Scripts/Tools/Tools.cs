﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    #region variables
    private SectionManager sectionManager;
    private ToolsManager toolManager;
    private TilesPuzzleManager tilePuzzleManager;
    private GameObject toolParent;

    private Transform resetPoint_02;

    private GameController gameController;

    public enum tool
    {
        statue01,
        statue02,
        statue03,
        tile_01,
        tile_02,
        tile_03,
        tile_04,
        crowbar,
    };
    public tool toolType;

    private ToolCollect toolCollect;
    #endregion

    #region start
    private void Start()
    {
        toolCollect = FindObjectOfType<ToolCollect>();
        sectionManager = FindObjectOfType<SectionManager>();
        toolManager = FindObjectOfType<ToolsManager>();
        tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();

        gameController = FindObjectOfType<GameController>();

        resetPoint_02 = GameObject.Find("Reset_02").transform;

        if(transform.tag == "Tile")
        {
            SelfDestruct parentObj = GetComponentInParent<SelfDestruct>();
            toolParent = parentObj.gameObject;
        }
        else if(transform.tag == "Tool")
        {
            toolParent = GetComponent<GameObject>();
        }


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
    }
    #endregion

    #region OnTriggerEnter and OnTriggerExit function calls
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
                            toolManager.tilesValue += 1;
                            toolManager.tileOneSequence = true;
                            Destroy(toolParent);
                        }
                        else
                        {
                            other.gameObject.transform.position = resetPoint_02.position;
                            toolManager.tilesValue = 0;

                            SelfDestruct[] removeTiles = FindObjectsOfType<SelfDestruct>();
                            foreach(SelfDestruct tile in removeTiles)
                            {
                                Destroy(tile.gameObject);
                            }

                            tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();
                            tilePuzzleManager.ResetTiles();
                        }
                    }
                    else if (GetComponent<Tools>().toolType == Tools.tool.tile_02)
                    {
                        if (toolManager.tileOneSequence == true && toolManager.tileThreeSequence == false
                            && toolManager.tileFourSequence == false)
                        {
                            toolManager.tilesValue += 1;
                            toolManager.tileTwoSequence = true;
                            Destroy(toolParent);
                        }
                        else
                        {
                            other.gameObject.transform.position = resetPoint_02.position;
                            toolManager.tilesValue = 0;

                            SelfDestruct[] removeTiles = FindObjectsOfType<SelfDestruct>();
                            foreach (SelfDestruct tile in removeTiles)
                            {
                                Destroy(tile.gameObject);
                            }

                            tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();
                            tilePuzzleManager.ResetTiles();
                        }
                    }
                    else if (GetComponent<Tools>().toolType == Tools.tool.tile_03)
                    {
                        if (toolManager.tileOneSequence == true && toolManager.tileTwoSequence == true
                            && toolManager.tileFourSequence == false)
                        {
                            toolManager.tilesValue += 1;
                            toolManager.tileThreeSequence = true;
                            Destroy(toolParent);
                        }
                        else
                        {
                            other.gameObject.transform.position = resetPoint_02.position;
                            toolManager.tilesValue = 0;

                            SelfDestruct[] removeTiles = FindObjectsOfType<SelfDestruct>();
                            foreach (SelfDestruct tile in removeTiles)
                            {
                                Destroy(tile.gameObject);
                            }

                            tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();
                            tilePuzzleManager.ResetTiles();
                        }
                    }
                    else if (GetComponent<Tools>().toolType == Tools.tool.tile_04)
                    {
                        if (toolManager.tileOneSequence == true && toolManager.tileTwoSequence == true
                            && toolManager.tileThreeSequence == true)
                        {
                            toolManager.tilesValue += 1;
                            toolManager.tileFourSequence = true;
                            Destroy(toolParent);
                            if (toolManager.tilesValue == 4)
                            {
                                tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();
                                tilePuzzleManager.sectionDoor.SetActive(false);
                                SectionManager sectionManager = FindObjectOfType<SectionManager>();
                                sectionManager.masionPuzzle_F1_02 = true;

                                gameController.Save();

                                tilePuzzleManager.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            other.gameObject.transform.position = resetPoint_02.position;
                            toolManager.tilesValue = 0;

                            SelfDestruct[] removeTiles = FindObjectsOfType<SelfDestruct>();
                            foreach (SelfDestruct tile in removeTiles)
                            {
                                Destroy(tile.gameObject);
                            }

                            tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();
                            tilePuzzleManager.ResetTiles();
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
