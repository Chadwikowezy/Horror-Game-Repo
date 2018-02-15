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

    private SectionManager sectionManager;
    private GameController gameController;
    #endregion

    #region Functions
	void Start ()
    {
        toolCollect = FindObjectOfType<ToolCollect>();
        sectionManager = FindObjectOfType<SectionManager>();
        gameController = FindObjectOfType<GameController>();

        foreach (Tools tool in tools)
        {
            toolCollect.mausoleumTools.Add(tool);
        }
    }
	
	void Update ()
    {
        //print(tools);	

	}

    public void sceneChange()
    {
        sectionManager.cryptPuzzle = true;
        gameController.Save();

        SceneManager.LoadScene("Graveyard Cutscene");
    }
    #endregion
}
