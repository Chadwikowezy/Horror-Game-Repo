using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard_CollectObject : MonoBehaviour
{
    public GameObject collectButton;
    public string tagToCheck = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToCheck))
            collectButton.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagToCheck))
            collectButton.SetActive(false);
    }
}
