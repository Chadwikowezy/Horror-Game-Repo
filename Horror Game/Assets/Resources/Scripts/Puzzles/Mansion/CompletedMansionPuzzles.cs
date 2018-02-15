using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedMansionPuzzles : MonoBehaviour
{
    private Actor actor;
    private SectionManager sectionManager;
    private GameController gameController;
    public GameObject completedMansionImg;

    void OnTriggerEnter(Collider other)
    {
        actor = FindObjectOfType<Actor>();
        gameController = FindObjectOfType<GameController>();
        sectionManager = FindObjectOfType<SectionManager>();

        if (actor.data.masionPuzzle_F2_01 == false)
        {
            if (other.gameObject.tag == "Player")
            {
                sectionManager.masionPuzzle_F2_01 = true;

                gameController.Save();

                StartCoroutine(LoadNextScene());
            }
        }
    }	

    IEnumerator LoadNextScene()
    {
        completedMansionImg.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Maze-Crypt");
    }
}
