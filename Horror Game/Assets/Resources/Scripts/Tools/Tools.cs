using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    private SectionManager sectionManager;

    public enum tool
    {
        statue01,
        statue02,
        statue03,
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickupButton.GetComponent<ToolCollect>().collectDisplay.SetActive(true);
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
