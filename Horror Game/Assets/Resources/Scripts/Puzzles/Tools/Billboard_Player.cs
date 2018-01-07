using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard_Player : MonoBehaviour
{
    #region variables
    private PlayerMotor player;
    private Vector3 lookVector;
    public GameObject childImg;
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
        if(Vector3.Distance(player.transform.position, transform.position) <= 4f)
        {
            childImg.SetActive(true);
            lookVector = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(lookVector);
        }
        else
        {
            childImg.SetActive(false);
        }
    }
    #endregion
}
