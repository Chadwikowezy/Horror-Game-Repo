using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletedMansionPuzzles : MonoBehaviour
{
    private Actor actor;
    private GameController gameController;

    public StatuePuzzleManager statuePuzzleManager;
    public TilesPuzzleManager tilesPuzzleManager;
    public SafePuzzleManager safePuzzleManager;
    public InvisibleFloorPuzzleManager invisibleFloorPuzzleManager;

    void OnTriggerEnter(Collider other)
    {
        actor = FindObjectOfType<Actor>();
        gameController = FindObjectOfType<GameController>();

        if(actor.data.masionPuzzle_F2_01 == false)
        {
            if (other.gameObject.tag == "Player")
            {
                actor.data.masionPuzzle_F2_01 = true;
                gameController.Save();
                invisibleFloorPuzzleManager.beginFogFollow = false;
                invisibleFloorPuzzleManager.fogEffect.SetActive(false);

                statuePuzzleManager.gameObject.SetActive(false);
                tilesPuzzleManager.gameObject.SetActive(false);
                safePuzzleManager.gameObject.SetActive(false);
                //play transition 
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }	
}
