using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
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
