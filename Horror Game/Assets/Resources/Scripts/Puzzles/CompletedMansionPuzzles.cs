using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedMansionPuzzles : MonoBehaviour
{
    private Actor actor;
    private GameController gameController;
    public GameObject completedMansionImg;

    void OnTriggerEnter(Collider other)
    {
        actor = FindObjectOfType<Actor>();
        gameController = FindObjectOfType<GameController>();

        if (actor.data.masionPuzzle_F2_01 == false)
        {
            if (other.gameObject.tag == "Player")
            {
                actor.data.masionPuzzle_F2_01 = true;

                gameController.Save();

                StartCoroutine(LoadNextScene());
            }
        }
    }	

    IEnumerator LoadNextScene()
    {
        completedMansionImg.SetActive(true);
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(3);
    }
}
