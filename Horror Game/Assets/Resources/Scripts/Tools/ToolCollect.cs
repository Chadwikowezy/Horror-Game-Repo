using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolCollect : MonoBehaviour
{
    #region variables
    public List<Tools> sectionOneTools = new List<Tools>();

    private PlayerMotor player;
    private ToolsManager toolManager;

    public GameObject collectDisplay;

    private bool pickedUp;

    private GameController gameController;

    private TilesPuzzleManager tilePuzzleManager;

    public Sprite
        statueSprite,
        crowbarSprite;
    #endregion

    #region Start
    void Start()
    {
        player = FindObjectOfType<PlayerMotor>();
        toolManager = FindObjectOfType<ToolsManager>();
        gameController = FindObjectOfType<GameController>();
    }
    #endregion

    #region Assign Toolbar image sprites
    void AssignToolSprite(Tools tool)
    {
        toolManager = FindObjectOfType<ToolsManager>();

        if (tool.toolType == Tools.tool.statue01)
        {
            toolManager.toolBar01.sprite = statueSprite;
        }
        else if (tool.toolType == Tools.tool.statue02)
        {
            toolManager.toolBar02.sprite = statueSprite;
        }
        else if (tool.toolType == Tools.tool.statue03)
        {
            toolManager.toolBar03.sprite = statueSprite;
        }        
    }
    #endregion

    #region Collect Tool function call
    public void CollectTool()
    {
        foreach(Tools tool in sectionOneTools)
        {
            if (tool != null)
            {
                if (Vector3.Distance(player.transform.position, tool.gameObject.transform.position) <= 2f)
                {
                    if (tool.GetComponent<Tools>().toolType == Tools.tool.statue01)
                    {
                        toolManager.knightsStatue += 1;
                        AssignToolSprite(tool);
                        Destroy(tool.gameObject);
                        pickedUp = true;
                        collectDisplay.SetActive(false);
                    }
                    if (tool.GetComponent<Tools>().toolType == Tools.tool.statue02)
                    {
                        toolManager.knightsStatue += 1;
                        AssignToolSprite(tool);
                        Destroy(tool.gameObject);
                        pickedUp = true;
                        collectDisplay.SetActive(false);
                    }
                    if (tool.GetComponent<Tools>().toolType == Tools.tool.statue03)
                    {
                        toolManager.knightsStatue += 1;
                        AssignToolSprite(tool);
                        Destroy(tool.gameObject);
                        pickedUp = true;
                        collectDisplay.SetActive(false);
                    }                                                                      
                }
            }            
        }
        gameController.Save();
    }
    #endregion
}
