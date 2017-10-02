using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    private SectionManager sectionManager;
    private ToolsManager toolManager;
    private TilesPuzzleManager tilePuzzleManager;
    public SelfDestruct[] toolParentObjs;

    public Transform resetPoint_02;

    public enum tool
    {
        statue01,
        statue02,
        statue03,
        tile_01,
        tile_02,
        tile_03,
        tile_04,
        key01,
        key02,
        key03,
        crowbar,
        lockpick,
        rope
    };
    public tool toolType;

    public GameObject pickupButton;

    private void Start()
    {
        pickupButton = GameObject.Find("ToolsCollect");
        sectionManager = FindObjectOfType<SectionManager>();
        toolManager = FindObjectOfType<ToolsManager>();
        tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();
        resetPoint_02 = GameObject.Find("Reset_02").transform;
        toolParentObjs = FindObjectsOfType<SelfDestruct>();
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

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < 1; i++)
        {
            if (other.gameObject.tag == "Player")
            {
                if (gameObject.tag == "Tool")
                {
                    pickupButton.GetComponent<ToolCollect>().collectDisplay.SetActive(true);
                }
                if (gameObject.tag == "Tile")
                {
                    if (GetComponent<Tools>().toolType == Tools.tool.tile_01)
                    {
                        if (toolManager.tileTwoSequence == false && toolManager.tileThreeSequence == false
                            && toolManager.tileFourSequence == false)
                        {
                            toolManager.tilesValue += 1;
                            toolManager.tileOneSequence = true;
                            Destroy(gameObject.GetComponentInParent<SelfDestruct>().gameObject);
                        }
                        else
                        {
                            other.gameObject.transform.position = resetPoint_02.position;
                            toolManager.tilesValue = 0;
                            toolParentObjs = FindObjectsOfType<SelfDestruct>();
                            foreach (SelfDestruct oldTools in toolParentObjs)
                            {
                                Destroy(oldTools.gameObject);
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
                            Destroy(gameObject.GetComponentInParent<SelfDestruct>().gameObject);
                        }
                        else
                        {
                            other.gameObject.transform.position = resetPoint_02.position;
                            toolManager.tilesValue = 0;
                            toolParentObjs = FindObjectsOfType<SelfDestruct>();
                            foreach (SelfDestruct oldTools in toolParentObjs)
                            {
                                Destroy(oldTools.gameObject);
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
                            Destroy(gameObject.GetComponentInParent<SelfDestruct>().gameObject);
                        }
                        else
                        {
                            other.gameObject.transform.position = resetPoint_02.position;
                            toolManager.tilesValue = 0;
                            toolParentObjs = FindObjectsOfType<SelfDestruct>();
                            foreach (SelfDestruct oldTools in toolParentObjs)
                            {
                                Destroy(oldTools.gameObject);
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
                            if (toolManager.tilesValue == 4)
                            {
                                tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();
                                tilePuzzleManager.sectionDoor.SetActive(false);
                                SectionManager sectionManager = FindObjectOfType<SectionManager>();
                                sectionManager.masionPuzzle_F1_02 = true;
                                Destroy(gameObject.GetComponentInParent<SelfDestruct>().gameObject);
                                tilePuzzleManager.gameObject.SetActive(false);
                            }
                        }
                        else
                        {
                            other.gameObject.transform.position = resetPoint_02.position;
                            toolManager.tilesValue = 0;
                            toolParentObjs = FindObjectsOfType<SelfDestruct>();
                            foreach (SelfDestruct oldTools in toolParentObjs)
                            {
                                Destroy(oldTools.gameObject);
                            }
                            tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();
                            tilePuzzleManager.ResetTiles();
                        }
                    }
                }
            }
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickupButton.GetComponent<ToolCollect>().collectDisplay.SetActive(false);
        }
    }
}
