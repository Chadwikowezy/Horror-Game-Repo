using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleCanvas : MonoBehaviour
{
    #region variables
    public bool canUseButtons;

    //private float framerate = 0.0f;
    //public Text framerateTxt;

    static int desiredFramerate = 60;
    #endregion

    #region awake & start
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = desiredFramerate;       
    }

    void Start()
    {
        canUseButtons = true;
    }

    //void Update()
    //{
    //    framerate += (Time.unscaledDeltaTime - framerate) * 0.1f;
    //    float msec = framerate * 1000.0f;
    //    float fps = 1.0f / framerate;

    //    framerateTxt.text = "Framerate: " + ((int)fps).ToString();
    //}
    #endregion
}