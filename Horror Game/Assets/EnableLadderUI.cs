using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLadderUI : MonoBehaviour
{
    private AllowClimb allowClimb;

    private PlayerMotor player;
    private HandleCanvas handleCanvas;

    void Start()
    {
        player = FindObjectOfType<PlayerMotor>();
        handleCanvas = FindObjectOfType<HandleCanvas>();
        allowClimb = GetComponentInParent<AllowClimb>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMotor>())
        {
            allowClimb.climbButton.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMotor>())
        {
            allowClimb.climbButton.SetActive(false);
        }
    }
}
