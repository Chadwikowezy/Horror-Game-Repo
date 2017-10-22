using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCanvas : MonoBehaviour
{
    #region variables
    public bool canUseButtons;
    public bool inAnimationState;
    public bool movementJoytickStop;
    #endregion

    #region start
    void Start()
    {
        canUseButtons = true;
        inAnimationState = false;
    }
    #endregion
}