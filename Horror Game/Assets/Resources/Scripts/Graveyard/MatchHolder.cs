using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchHolder : MonoBehaviour
{
    public GameObject animatedMatch;

    public MatchManager manager;

    public int matchCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animatedMatch.SetActive(true);
            manager.toggleMatchCollectButton(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            animatedMatch.SetActive(false);
    }
}
