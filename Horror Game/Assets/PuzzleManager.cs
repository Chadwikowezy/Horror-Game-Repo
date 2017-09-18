using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    public GameObject[] statueDisplayObjs;
    public Image[] toolUISlots;
    private ToolsManager toolManager;

    private SectionManager sectionManager;

    public Sprite transparentEmpty;

	void Start ()
    {
        toolManager = FindObjectOfType<ToolsManager>();
        sectionManager = FindObjectOfType<SectionManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(toolManager.knightsStatue == 3)
            {
                foreach(GameObject statue in statueDisplayObjs)
                {
                    statue.SetActive(true);
                }
                foreach (Image toolUI in toolUISlots)
                {
                    toolUI.sprite = transparentEmpty;
                }
                sectionManager.sectionOneCleared = true;
            }
        }
    }
}
