using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneLaunchManager : MonoBehaviour
{
    private Actor actor;
    private GameController gameController;

	public void RecievedCall ()
    {
        actor = FindObjectOfType<Actor>();
        gameController = FindObjectOfType<GameController>();
    }

    public void StartButton()
    {
        StartCoroutine(StartDelay());
    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(3f);
        //SceneManager.LoadScene("OpeningCutscene");
        actor.ResetDataAttributes();
        gameController.Save();
        SceneManager.LoadScene("Mansion");
    }


    public void ContinueButton()
    {
        StartCoroutine(ContinueDelay());
    }
    IEnumerator ContinueDelay()
    {
        yield return new WaitForSeconds(3f);
        if (System.IO.File.Exists(Path.Combine(Application.persistentDataPath, "actors.json")))
        {
            if (actor.data.masionPuzzle_F1_01 == false ||
            actor.data.masionPuzzle_F1_02 == false ||
            actor.data.masionPuzzle_F1_03 == false ||
            actor.data.masionPuzzle_F2_01 == false)
            {
                SceneManager.LoadScene("Mansion");
            }
            else if (actor.data.masionPuzzle_F2_01 == true &&
                actor.data.mausoleumPuzzle == false ||
                actor.data.cryptPuzzle == false)
            {
                SceneManager.LoadScene("Maze-Crypt");
            }
            else if (actor.data.cryptPuzzle == true &&
                actor.data.graveYardPuzzle == false)
            {
                SceneManager.LoadScene("Graveyard");
            }
        }
    }
}
