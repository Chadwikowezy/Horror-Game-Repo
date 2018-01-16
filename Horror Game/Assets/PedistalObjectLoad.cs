using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedistalObjectLoad : MonoBehaviour
{
    public List<GameObject> pedistalObjects = new List<GameObject>();
    private ToolsManager toolManager;
    
    public enum pedistalObject { PEDISTAL01, PEDISTAL02, PEDISTAL03 };
    public pedistalObject thisPedistal;

    public void ReceievedCall()
    {
        toolManager = FindObjectOfType<ToolsManager>();

        if (thisPedistal == pedistalObject.PEDISTAL01)
        {
            if (toolManager.statueSequence01 == 1)
            {
                pedistalObjects[0].SetActive(true);
            }
            else if (toolManager.statueSequence01 == 2)
            {
                pedistalObjects[1].SetActive(true);
            }
            else if (toolManager.statueSequence01 == 3)
            {
                pedistalObjects[2].SetActive(true);
            }
            else if (toolManager.statueSequence01 == 4)
            {
                pedistalObjects[3].SetActive(true);
            }
            else if (toolManager.statueSequence01 == 5)
            {
                pedistalObjects[4].SetActive(true);
            }
            else if (toolManager.statueSequence01 == 6)
            {
                pedistalObjects[5].SetActive(true);
            }
        }
        else if (thisPedistal == pedistalObject.PEDISTAL02)
        {
            if (toolManager.statueSequence02 == 1)
            {
                pedistalObjects[0].SetActive(true);
            }
            else if (toolManager.statueSequence02 == 2)
            {
                pedistalObjects[1].SetActive(true);
            }
            else if (toolManager.statueSequence02 == 3)
            {
                pedistalObjects[2].SetActive(true);
            }
            else if (toolManager.statueSequence02 == 4)
            {
                pedistalObjects[3].SetActive(true);
            }
            else if (toolManager.statueSequence02 == 5)
            {
                pedistalObjects[4].SetActive(true);
            }
            else if (toolManager.statueSequence02 == 6)
            {
                pedistalObjects[5].SetActive(true);
            }
        }
        else if (thisPedistal == pedistalObject.PEDISTAL03)
        {
            if (toolManager.statueSequence03 == 1)
            {
                pedistalObjects[0].SetActive(true);
            }
            else if (toolManager.statueSequence03 == 2)
            {
                pedistalObjects[1].SetActive(true);
            }
            else if (toolManager.statueSequence03 == 3)
            {
                pedistalObjects[2].SetActive(true);
            }
            else if (toolManager.statueSequence03 == 4)
            {
                pedistalObjects[3].SetActive(true);
            }
            else if (toolManager.statueSequence03 == 5)
            {
                pedistalObjects[4].SetActive(true);
            }
            else if (toolManager.statueSequence03 == 6)
            {
                pedistalObjects[5].SetActive(true);
            }
        }
    }
}
