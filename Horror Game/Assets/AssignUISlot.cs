using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignUISlot : MonoBehaviour
{
    private ToolsManager toolManager;
    public enum ToolType { empty, key01, key02, crowbar };
    public ToolType toolType;

    public bool slotOneFilled = false;
    public bool slotTwoFilled = false;
    public bool slotThreeFilled = false;

    public Sprite
       keySprite,
       crowbarSprite;

    void Start()
    {
        toolManager = FindObjectOfType<ToolsManager>();
    }

    public void AssignToolSprite(ToolType tool)
    {
        #region keys and crowbar
        if (tool == ToolType.key01)
        {
            if (slotOneFilled == false)
            {
                toolManager.toolBar01.sprite = keySprite;
                slotOneFilled = true;
            }
            else if (slotTwoFilled == false)
            {
                toolManager.toolBar02.sprite = keySprite;
                slotTwoFilled = true;
            }
            else if (slotThreeFilled == false)
            {
                toolManager.toolBar03.sprite = keySprite;
                slotThreeFilled = true;
            }
        }
        else if (tool == ToolType.key02)
        {
            if (slotOneFilled == false)
            {
                toolManager.toolBar01.sprite = keySprite;
                slotOneFilled = true;
            }
            else if (slotTwoFilled == false)
            {
                toolManager.toolBar02.sprite = keySprite;
                slotTwoFilled = true;
            }
            else if (slotThreeFilled == false)
            {
                toolManager.toolBar03.sprite = keySprite;
                slotThreeFilled = true;
            }
        }
        else if (tool == ToolType.crowbar)
        {
            if (slotOneFilled == false)
            {
                toolManager.toolBar01.sprite = crowbarSprite;
                slotOneFilled = true;
            }
            else if (slotTwoFilled == false)
            {
                toolManager.toolBar02.sprite = crowbarSprite;
                slotTwoFilled = true;
            }
            else if (slotThreeFilled == false)
            {
                toolManager.toolBar03.sprite = crowbarSprite;
                slotThreeFilled = true;
            }
        }
        #endregion
    }
}
