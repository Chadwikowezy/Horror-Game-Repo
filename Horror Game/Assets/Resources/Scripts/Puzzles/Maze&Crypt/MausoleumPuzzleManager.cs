using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MausoleumPuzzleManager : MonoBehaviour
{
    #region Variables
    public List<Transform> keyTransforms = new List<Transform>();
    public Transform crowbarTransform;

    public List<Tools> tools = new List<Tools>();

    private ToolCollect toolCollect;
    #endregion

    #region Functions
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

    public void sceneChange()
    {
        SceneManager.LoadScene("Graveyard Cutscene", LoadSceneMode.Additive);
    }
    #endregion
}
