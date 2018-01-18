using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatuePuzzleManager : MonoBehaviour
{
    #region variables
    public GameObject[] statueDisplayObjs;
    public Image[] toolUISlots;
    private ToolsManager toolManager;
    private ToolCollect toolCollect;

    private SectionManager sectionManager;

    public Sprite transparentEmpty;

    private GameController gameController;

    private Actor actor;

    public GameObject statueObj01, statueObj02, statueObj03, statueObj04, statueObj05, statueObj06;
    public Transform[] spawnLocations;

    int spawnPoint_01, spawnPoint_02, spawnPoint_03, spawnPoint_04, spawnPoint_05, spawnPoint_06;

    public GameObject sectionDoor;

    public GameObject placeStatuesImg;
    public GameObject InsufficentMessage;

    private PhoneManager phoneManager;

    private Spector spector;
    #endregion

    #region recieve actor call to begin
    public void RecievedCall ()
    {
        toolManager = FindObjectOfType<ToolsManager>();
        sectionManager = FindObjectOfType<SectionManager>();
        spector = FindObjectOfType<Spector>();
        gameController = FindObjectOfType<GameController>();
        phoneManager = FindObjectOfType<PhoneManager>();
        placeStatuesImg.SetActive(false);
        InsufficentMessage.SetActive(false);

        if (sectionDoor == null)
        {
            sectionDoor = GameObject.Find("SectionDoor_01");
        }
        actor = FindObjectOfType<Actor>();
        if (actor.data.masionPuzzle_F1_01 == false)
        {
            sectionDoor.SetActive(true);
            while (spawnPoint_01 == spawnPoint_02 || spawnPoint_01 == spawnPoint_03 || spawnPoint_01 == spawnPoint_04 || spawnPoint_01 == spawnPoint_05 || spawnPoint_01 == spawnPoint_06)
            {
                spawnPoint_01 = (Random.Range(0, 12));
            }
            while (spawnPoint_02 == spawnPoint_01 || spawnPoint_02 == spawnPoint_03 || spawnPoint_02 == spawnPoint_04 || spawnPoint_02 == spawnPoint_05 || spawnPoint_02 == spawnPoint_06)
            {
                spawnPoint_02 = (Random.Range(0, 12));
            }
            while (spawnPoint_03 == spawnPoint_01 || spawnPoint_03 == spawnPoint_02 || spawnPoint_03 == spawnPoint_04 || spawnPoint_03 == spawnPoint_05 || spawnPoint_03 == spawnPoint_06)
            {
                spawnPoint_03 = (Random.Range(0, 12));
            }
            while (spawnPoint_04 == spawnPoint_01 || spawnPoint_04 == spawnPoint_02 || spawnPoint_04 == spawnPoint_03 || spawnPoint_04 == spawnPoint_05 || spawnPoint_04 == spawnPoint_06)
            {
                spawnPoint_04 = (Random.Range(0, 12));
            }
            while (spawnPoint_05 == spawnPoint_01 || spawnPoint_05 == spawnPoint_02 || spawnPoint_05 == spawnPoint_03 || spawnPoint_05 == spawnPoint_04 || spawnPoint_05 == spawnPoint_06)
            {
                spawnPoint_05 = (Random.Range(0, 12));
            }
            while (spawnPoint_06 == spawnPoint_01 || spawnPoint_06 == spawnPoint_02 || spawnPoint_06 == spawnPoint_03 || spawnPoint_06 == spawnPoint_04 || spawnPoint_06 == spawnPoint_05)
            {
                spawnPoint_06 = (Random.Range(0, 12));
            }


            GameObject statue01 = Instantiate(statueObj01, spawnLocations[spawnPoint_01].position,
                spawnLocations[spawnPoint_01].rotation);
            GameObject statue02 = Instantiate(statueObj02, spawnLocations[spawnPoint_02].position,
                spawnLocations[spawnPoint_02].rotation);
            GameObject statue03 = Instantiate(statueObj03, spawnLocations[spawnPoint_03].position,
                spawnLocations[spawnPoint_03].rotation);
            GameObject statue04 = Instantiate(statueObj04, spawnLocations[spawnPoint_04].position,
                spawnLocations[spawnPoint_04].rotation);
            GameObject statue05 = Instantiate(statueObj05, spawnLocations[spawnPoint_05].position,
                spawnLocations[spawnPoint_05].rotation);
            GameObject statue06 = Instantiate(statueObj06, spawnLocations[spawnPoint_06].position,
                spawnLocations[spawnPoint_06].rotation);

            toolCollect = FindObjectOfType<ToolCollect>();
            toolCollect.sectionOneTools.Add(statue01.GetComponent<Tools>());
            toolCollect.sectionOneTools.Add(statue02.GetComponent<Tools>());
            toolCollect.sectionOneTools.Add(statue03.GetComponent<Tools>());
            toolCollect.sectionOneTools.Add(statue04.GetComponent<Tools>());
            toolCollect.sectionOneTools.Add(statue05.GetComponent<Tools>());
            toolCollect.sectionOneTools.Add(statue06.GetComponent<Tools>());

            toolManager.statueSequence01 = Random.Range(1, 7);
            toolManager.statueSequence02 = Random.Range(1, 7);
            toolManager.statueSequence03 = Random.Range(1, 7);
            while (toolManager.statueSequence01 == toolManager.statueSequence02 || toolManager.statueSequence01 == toolManager.statueSequence03)
            {
                toolManager.statueSequence01 = Random.Range(1, 7);
            }
            while (toolManager.statueSequence02 == toolManager.statueSequence01 || toolManager.statueSequence02 == toolManager.statueSequence03)
            {
                toolManager.statueSequence02 = Random.Range(1, 7);
            }
            while (toolManager.statueSequence03 == toolManager.statueSequence01 || toolManager.statueSequence03 == toolManager.statueSequence02)
            {
                toolManager.statueSequence03 = Random.Range(1, 7);
            }

        }
        else if (actor.data.masionPuzzle_F1_01 == true)
        {
            sectionDoor.SetActive(false);
            foreach (GameObject stat in statueDisplayObjs)
            {
                stat.GetComponent<PedistalObjectLoad>().ReceievedCall();
            }
            gameObject.SetActive(false);
        }
    }
    #endregion

    #region OnTriggerEnter and OnTriggerExit function calls
    private void OnTriggerEnter(Collider other)
    {
        if(actor != null)
        {
            if (actor.data.masionPuzzle_F1_01 == false)
            {
                if (other.gameObject.tag == "Player")
                {
                    if (toolManager.statuesCollected == 3)
                    {
                        placeStatuesImg.SetActive(true);
                    }
                    else
                    {
                        InsufficentMessage.SetActive(true);
                    }
                }
            }
        }   
    }
    private void OnTriggerExit(Collider other)
    { 
        placeStatuesImg.SetActive(false);
        InsufficentMessage.SetActive(false);
    }
    #endregion

    #region placestatues button event call
    public void PlaceStatues()
    {
        if (toolManager.statuesCollected == 3 && toolManager.correctStatueSequence == true)
        {
            foreach (GameObject statue in statueDisplayObjs)
            {
                statue.GetComponent<PedistalObjectLoad>().ReceievedCall();
            }
            foreach (Image toolUI in toolUISlots)
            {
                toolUI.sprite = transparentEmpty;
            }
            sectionManager.masionPuzzle_F1_01 = true;
            TilesPuzzleManager tilePuzzleManager = FindObjectOfType<TilesPuzzleManager>();
            tilePuzzleManager.colorChartObj.SetActive(true);
            sectionDoor.SetActive(false);
            phoneManager.NewMessageNotification();
            gameController.Save();
            placeStatuesImg.SetActive(false);
            InsufficentMessage.SetActive(false);
        }
        if(toolManager.correctStatueSequence == false)
        {
            foreach (Tools statue in toolCollect.sectionOneTools)
            {
                statue.gameObject.SetActive(true);
                foreach (Image toolUI in toolUISlots)
                {
                    toolUI.sprite = transparentEmpty;
                }
                placeStatuesImg.SetActive(false);
                toolManager.statuesCollected = 0;
                toolCollect.slotOneFilled = false;
                toolCollect.slotTwoFilled = false;
                toolCollect.slotThreeFilled = false;
                toolCollect.correctSequence = 0;
            }
            spector.AlertPosition = transform.position;

        }
    }
    #endregion
}
