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

    private PlayerMotor player;
    public Transform teleportPositionOutside;
    public Transform teleportPositionInside;

    private RainFollowPlayer rainFollowPlayer;

    void OnTriggerEnter(Collider other)
    {
        actor = FindObjectOfType<Actor>();
        gameController = FindObjectOfType<GameController>();
        rainFollowPlayer = FindObjectOfType<RainFollowPlayer>();
        player = FindObjectOfType<PlayerMotor>();

        if (actor.data.masionPuzzle_F2_01 == false)
        {
            if (other.gameObject.tag == "Player")
            {

                invisibleFloorPuzzleManager.beginFogFollow = false;
                invisibleFloorPuzzleManager.fogEffect.SetActive(false);

                actor.data.isOutside = true;
                rainFollowPlayer.CheckIfCanFollow();

                actor.data.masionPuzzle_F2_01 = true;

                player.transform.position = teleportPositionOutside.transform.position;

                gameController.Save();

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
