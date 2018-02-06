using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleFloorPuzzleManager : MonoBehaviour
{
    private PlayerMotor player;

    public List<GameObject> alertTiles = new List<GameObject>();
    public List<GameObject> pullThruTiles = new List<GameObject>();

    public Transform fogEnableRange;
    public GameObject fogEffect;
    public bool hasFallen = true;
    public bool beginFogFollow = false;
    public GameObject[] fogEffects;


    void Start()
    {
        player = FindObjectOfType<PlayerMotor>();
    }

    void Update()
    {
        CheckTileLists();
        EnableFogSystem();
        if(beginFogFollow == true)
        {
            FogFollowPlayer(fogEffect.gameObject.transform);
        }
    }

    public void FogFollowPlayer(Transform fog)
    {
        if(hasFallen == false)
        {
            fogEffect.SetActive(true);
            Vector3 playerVec = new Vector3(player.transform.position.x + 5, fog.position.y, player.transform.position.z);
            fog.transform.position = playerVec;
        }    
    }

    void EnableFogSystem()
    {
        //enable left side
        if (Vector3.Distance (fogEnableRange.transform.position, player.transform.position) <= 15f && beginFogFollow == false)
        {
            foreach (GameObject fog in fogEffects)
            {
                fog.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject fog in fogEffects)
            {
                fog.SetActive(false);
            }
        }
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
