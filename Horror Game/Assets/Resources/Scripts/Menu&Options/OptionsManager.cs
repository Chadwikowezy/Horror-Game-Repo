using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour
{
    private Actor actor;
    private GameController gameController;
    public GameObject optionsPanel;

    public List<GameObject> difficultyButtons = new List<GameObject>();
    public Slider audioLevel;
    public Slider sensitivity;

    private CameraMotor camMotor;
    private InsanityManager insanityManager;

    void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Main Menu") &&
          SceneManager.GetActiveScene() != SceneManager.GetSceneByName("OpeningCutscene"))
        {
            camMotor = FindObjectOfType<CameraMotor>();
            insanityManager = FindObjectOfType<InsanityManager>();
        }
    }

    //create a recieved call here, call it in actors start

    public void OptionsSet()
    {
        actor = FindObjectOfType<Actor>();
        gameController = FindObjectOfType<GameController>();

        actor.data.audioLevel = (int)audioLevel.value;
        actor.data.sensitivity = (int)sensitivity.value;
        if (actor.data.setMaxInsanity <= 0)
        {
            actor.data.setMaxInsanity = 3;
        }
        gameController.Save();
    }
    public void SetDifficulty(int scaleValue)
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Main Menu") &&
          SceneManager.GetActiveScene() != SceneManager.GetSceneByName("OpeningCutscene") &&
          SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Graveyard Cutscene"))
        {
            gameController = FindObjectOfType<GameController>();
            actor = FindObjectOfType<Actor>();
            actor.data.setMaxInsanity = scaleValue;

            gameController.Save();
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
    public void OptionsToggle()
    {
        optionsPanel.SetActive(!optionsPanel.active);

        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Main Menu") &&
          SceneManager.GetActiveScene() != SceneManager.GetSceneByName("OpeningCutscene"))
        {
            if (optionsPanel == enabled)
            {
                actor = FindObjectOfType<Actor>();

                sensitivity.value = actor.data.sensitivity;
                camMotor.sensitivityX = sensitivity.value;
                camMotor.sensitivityY = sensitivity.value;

                insanityManager.maxInsanity = actor.data.setMaxInsanity;

                audioLevel.value = actor.data.audioLevel;
            }
        }
    }
}
