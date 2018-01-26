using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    private Actor actor;
    private GameController gameController;
    public GameObject optionsPanel;

    public Slider audioLevel;
    public Slider lightLevel;
    public Slider sensitivity;

    private CameraMotor camMotor;
    private InsanityManager insanityManager;

    public int lightValue;
    public int audioValue;
    public int sensitivityValue;

    void Start()
    {
        camMotor = FindObjectOfType<CameraMotor>();
        insanityManager = FindObjectOfType<InsanityManager>();
    }

    //create a recieved call here, call it in actors start

    public void OptionsSet()
    {
        actor = FindObjectOfType<Actor>();
        gameController = FindObjectOfType<GameController>();

        actor.data.audioLevel = (int)audioLevel.value;
        actor.data.lightLevel = (int)lightLevel.value;
        actor.data.sensitivity = (int)sensitivity.value;
        if (actor.data.setMaxInsanity <= 0)
        {
            actor.data.setMaxInsanity = 3;
        }
        gameController.Save();
    }
    public void SetDifficulty(int scaleValue)
    {
        actor.data.setMaxInsanity = scaleValue;
    }
    public void OptionsToggle()
    {
        optionsPanel.SetActive(!optionsPanel.active);
    }
}
