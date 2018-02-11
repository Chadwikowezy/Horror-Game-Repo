using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectPills : MonoBehaviour
{
    private InsanityManager insanityManager;

    public GameObject collectPillImg;
    public GameObject pillsFullMessage;

    public bool activePill = false;

    void Start()
    {
        insanityManager = FindObjectOfType<InsanityManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(insanityManager.PillStackCount < insanityManager.pillStackMax)
            {
                collectPillImg.SetActive(true);
                activePill = true;
            }
            else
            {
                pillsFullMessage.SetActive(true);
            }
        }
    }

    void Update()
    {
        if (insanityManager.justCollected == true && activePill == true)
        {
            collectPillImg.SetActive(false);
            insanityManager.justCollected = false;
            activePill = false;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collectPillImg.SetActive(false);
            pillsFullMessage.SetActive(false);
            activePill = false;
        }
    }
}
