using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MausoleumPuzzleManager : MonoBehaviour
{
    public List<Transform> keyTransforms = new List<Transform>();
    public Transform crowbarTransform;

    public List<Tools> tools = new List<Tools>();

    private ToolCollect toolCollect;

	void Start ()
    {
        toolCollect = FindObjectOfType<ToolCollect>();
        foreach (Tools tool in tools)
        {
            toolCollect.mausoleumTools.Add(tool);
        }
    }
	
	void Update ()
    {
		
	}
}
