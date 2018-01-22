using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard_Player : MonoBehaviour
{
    #region variables
    private PlayerMotor player;
    public GameObject exclamationPoint;
    #endregion

    #region Start
    void Start()
    {
        player = FindObjectOfType<PlayerMotor>();
    }
    #endregion

    #region update
    void Update ()
    {
        if(Vector3.Distance(player.transform.position, transform.position) <= 5f)
        {
            exclamationPoint.SetActive(true);
        }
        else
        {
            exclamationPoint.SetActive(false);
        }
    }
    #endregion
}
