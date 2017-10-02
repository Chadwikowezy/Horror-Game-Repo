using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolCollect : MonoBehaviour
{
    public List<Tools> sectionOneTools = new List<Tools>();

    private PlayerMotor player;
    private ToolsManager toolManager;

    public GameObject collectDisplay;

    private bool pickedUp;

    private GameController gameController;

    private TilesPuzzleManager tilePuzzleManager;

    public Sprite
        statueSprite,
        keySprite,
        crowbarSprite,
        lockpickSprite,
        ropeSprite;


    void Start()
    {
        player = FindObjectOfType<PlayerMotor>();
        toolManager = FindObjectOfType<ToolsManager>();
        gameController = FindObjectOfType<GameController>();
    }

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
        if (tool.toolType == Tools.tool.key01)
        {
            toolManager.toolBar01.sprite = keySprite;
        }
        else if (tool.toolType == Tools.tool.key02)
        {
            toolManager.toolBar02.sprite = keySprite;
        }
        else if (tool.toolType == Tools.tool.key03)
        {
            toolManager.toolBar03.sprite = keySprite;
        }
    }

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
}
