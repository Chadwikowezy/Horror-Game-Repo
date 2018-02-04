using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard_CollectObject : MonoBehaviour
{
    public GameObject collectButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            collectButton.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            collectButton.SetActive(false);
    }
}
