using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuePuzzleManager : MonoBehaviour
{
    public GameObject[] statueDisplayObjs;
    public Image[] toolUISlots;
    private ToolsManager toolManager;
    private ToolCollect toolCollect;

    private SectionManager sectionManager;

    public Sprite transparentEmpty;

    private GameController gameController;

    private Actor actor;

    public GameObject statueObj01, statueObj02, statueObj03;
    public Transform[] spawnLocations;

    int spawnPoint_01, spawnPoint_02, spawnPoint_03;

    public GameObject sectionDoor;

    void Start ()
    {
        toolManager = FindObjectOfType<ToolsManager>();
        sectionManager = FindObjectOfType<SectionManager>();
        gameController = FindObjectOfType<GameController>();

        if(sectionDoor == null)
        {
            sectionDoor = GameObject.Find("SectionDoor_01");
        }

        if(actor == null)
        {
            actor = FindObjectOfType<Actor>();
        }

        if (actor.data.masionPuzzle_F1_01 == false)
        {
            sectionDoor.SetActive(true);
            while (spawnPoint_01 == spawnPoint_02 || spawnPoint_01 == spawnPoint_03)
            {
                spawnPoint_01 = Random.Range(0, 9);
            }
            while (spawnPoint_02 == spawnPoint_01 || spawnPoint_02 == spawnPoint_03)
            {
                spawnPoint_02 = Random.Range(0, 9);
            }
            while (spawnPoint_03 == spawnPoint_01 || spawnPoint_03 == spawnPoint_02)
            {
                spawnPoint_03 = Random.Range(0, 9);
            }
            GameObject statue01 = Instantiate(statueObj01, spawnLocations[spawnPoint_01].position,
                spawnLocations[spawnPoint_01].rotation);
            GameObject statue02 = Instantiate(statueObj02, spawnLocations[spawnPoint_02].position,
                spawnLocations[spawnPoint_02].rotation);
            GameObject statue03 = Instantiate(statueObj03, spawnLocations[spawnPoint_03].position,
                spawnLocations[spawnPoint_03].rotation);

            toolCollect = FindObjectOfType<ToolCollect>();
            toolCollect.sectionOneTools.Add(statue01.GetComponent<Tools>());
            toolCollect.sectionOneTools.Add(statue02.GetComponent<Tools>());
            toolCollect.sectionOneTools.Add(statue03.GetComponent<Tools>());
        }
        else if(actor.data.masionPuzzle_F1_01 == true)
        {
            sectionDoor.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(toolManager.knightsStatue == 3)
            {
                foreach(GameObject statue in statueDisplayObjs)
                {
                    statue.SetActive(true);
                }
                foreach (Image toolUI in toolUISlots)
                {
                    toolUI.sprite = transparentEmpty;
                }
                sectionManager.masionPuzzle_F1_01 = true;
                sectionDoor.SetActive(false);
                gameController.Save();
            }
        }
    }
}
