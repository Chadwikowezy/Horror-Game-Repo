using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Button : MonoBehaviour
{
    private AssignUISlot assignUI;

	void Start ()
    {
        assignUI = FindObjectOfType<AssignUISlot>();
    }
	
    public void AddObject_01()
    {
        assignUI.AssignToolSprite(AssignUISlot.ToolType.key01);
    }
    public void AddObject_02()
    {
        assignUI.AssignToolSprite(AssignUISlot.ToolType.key02);
    }
    public void AddObject_03()
    {
        assignUI.AssignToolSprite(AssignUISlot.ToolType.crowbar);
    }
}
