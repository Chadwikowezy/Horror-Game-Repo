using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCanvas : MonoBehaviour
{
    public bool canUseButtons;
    public bool inAnimationState;
    public bool movementJoytickStop;

    void Start()
    {
        canUseButtons = true;
        inAnimationState = false;
    }
}