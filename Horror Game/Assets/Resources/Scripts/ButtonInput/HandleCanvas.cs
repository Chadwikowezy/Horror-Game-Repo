using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleCanvas : MonoBehaviour
{
    #region variables
    public bool canUseButtons;
    public bool inAnimationState;
    public bool movementJoytickStop;

    private float framerate = 0.0f;
    public Text framerateTxt;
    #endregion

    #region awake & start
    void Awake()
    {
        Application.targetFrameRate = 45;       
    }

    void Start()
    {
        canUseButtons = true;
        inAnimationState = false;
    }

    void Update()
    {
        framerate += (Time.unscaledDeltaTime - framerate) * 0.1f;
        float msec = framerate * 1000.0f;
        float fps = 1.0f / framerate;

        framerateTxt.text = "Framerate: " + ((int)fps).ToString();
    }
    #endregion
}