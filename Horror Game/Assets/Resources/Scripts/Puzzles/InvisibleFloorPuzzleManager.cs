using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleFloorPuzzleManager : MonoBehaviour
{
    private PlayerMotor player;

    public List<GameObject> alertTiles = new List<GameObject>();
    public List<GameObject> pullThruTiles = new List<GameObject>();

    public Transform fogEffect;

    void Start()
    {
        player = FindObjectOfType<PlayerMotor>();
    }

    void Update()
    {
        CheckTileLists();
        FogFollowPlayer();
    }

    void FogFollowPlayer()
    {
        Vector3 playerVec = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        fogEffect.transform.position = playerVec;
    }

    void CheckTileLists()
    {
        for (int i = 0; i < alertTiles.Count; i++)
        {
            if (Vector3.Distance(player.transform.position, alertTiles[i].transform.position) < (4.5f))
            {
                alertTiles[i].SetActive(true);
            }
            else
            {
                if (alertTiles[i].GetComponent<Puzzle4_TileManager>().hasFinishedProcess == true)
                {
                    alertTiles[i].SetActive(false);
                }
            }
        }
        for (int i = 0; i < pullThruTiles.Count; i++)
        {
            if (Vector3.Distance(player.transform.position, pullThruTiles[i].transform.position) < (3f))
            {
                pullThruTiles[i].SetActive(true);
            }
            else
            {
                if (pullThruTiles[i].GetComponent<Puzzle4_TileManager>().hasFinishedProcess == true)
                {
                    pullThruTiles[i].SetActive(false);
                }
            }
        }
    }
}
