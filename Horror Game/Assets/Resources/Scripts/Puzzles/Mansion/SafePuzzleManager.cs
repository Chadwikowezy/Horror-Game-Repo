using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafePuzzleManager : MonoBehaviour
{
    #region variables
    public Transform[] numberSpawnPoints;
    public GameObject numberPrefab;
    public GameObject SafeLockCanvasObj;
    public GameObject safeUIPanel;
    public GameObject incorrectInputNotice;

    private int spawnPoint01, spawnPoint02, spawnPoint03, spawnPoint04;
    private int value_01, value_02, value_03;
    private int correctValue_01, correctValue_02, correctValue_03;

    public Text _val01, _val02, _val03;

    private Actor actor;
    private SectionManager sectionManager;
    public List<GameObject> sectionDoor = new List<GameObject>();
    private GameController gameController;

    private PhoneManager phoneManager;

    private AudioManager audioManager;
    #endregion

    #region recieved actor call to begin
    public void RecievedCall()
    {
        if(actor == null)
        {
            actor = FindObjectOfType<Actor>();
        }
        safeUIPanel.SetActive(false);
        incorrectInputNotice.SetActive(false);

        sectionManager = FindObjectOfType<SectionManager>();
        gameController = FindObjectOfType<GameController>();
        phoneManager = FindObjectOfType<PhoneManager>();
        audioManager = FindObjectOfType<AudioManager>();
        GenerateValues();
    }
    #endregion

    #region generating values and proceduraly placing numbers
    void GenerateValues()
    {
        if (actor.data.masionPuzzle_F1_03 == false)
        {
            for (int i = 0; i < sectionDoor.Count; i++)
            {
                sectionDoor[i].SetActive(true);
            }
            SafeLockCanvasObj.SetActive(true);
            correctValue_01 = Random.Range(0, 10);
            correctValue_02 = Random.Range(0, 10);
            correctValue_03 = Random.Range(0, 10);

            
            while (spawnPoint01 == spawnPoint02 || spawnPoint01 == spawnPoint03 || spawnPoint01 == spawnPoint04)
            {
                spawnPoint01 = (Random.Range(0, 3));
            }
            while (spawnPoint02 == spawnPoint01 || spawnPoint02 == spawnPoint03 || spawnPoint02 == spawnPoint04)
            {
                spawnPoint02 = (Random.Range(3, 6));
            }
            while (spawnPoint03 == spawnPoint01 || spawnPoint03 == spawnPoint02 || spawnPoint03 == spawnPoint04)
            {
                spawnPoint03 = (Random.Range(6, 9));
            }

            GameObject valueObj_01 = Instantiate(numberPrefab,
                numberSpawnPoints[spawnPoint01].GetChild(0).transform.position,
                numberSpawnPoints[spawnPoint01].transform.rotation);

            GameObject valueObj_02 = Instantiate(numberPrefab,
               numberSpawnPoints[spawnPoint02].GetChild(0).transform.position,
               numberSpawnPoints[spawnPoint02].transform.rotation);

            GameObject valueObj_03 = Instantiate(numberPrefab,
               numberSpawnPoints[spawnPoint03].GetChild(0).transform.position,
               numberSpawnPoints[spawnPoint03].transform.rotation);

            valueObj_01.GetComponentInChildren<Text>().text = correctValue_01.ToString();
            valueObj_02.GetComponentInChildren<Text>().text = correctValue_02.ToString();
            valueObj_03.GetComponentInChildren<Text>().text = correctValue_03.ToString();           
        }
        else if (actor.data.masionPuzzle_F1_03 == true)
        {
            SafeLockCanvasObj.SetActive(false);
            for (int i = 0; i < sectionDoor.Count; i++)
            {
                sectionDoor[i].GetComponent<Animator>().SetInteger("Open", 1);
            }
            audioManager.ObjectBegin(1);//play door creek
            gameObject.SetActive(false);
        }
    }
    #endregion

    #region Value Increment and Decrement button events
    public void IncrementValue01()
    {
        if(value_01 < 9)
        {
            value_01 += 1;
            _val01.text = value_01.ToString();
        }
    }
    public void DecrementValue01()
    {
        if(value_01 > 0)
        {
            value_01 -= 1;
            _val01.text = value_01.ToString();
        }
    }

    public void IncrementValue02()
    {
        if (value_02 < 9)
        {
            value_02 += 1;
            _val02.text = value_02.ToString();
        }
    }
    public void DecrementValue02()
    {
        if (value_02 > 0)
        {
            value_02 -= 1;
            _val02.text = value_02.ToString();
        }
    }

    public void IncrementValue03()
    {
        if (value_03 < 9)
        {
            value_03 += 1;
            _val03.text = value_03.ToString();
        }
    }
    public void DecrementValue03()
    {
        if (value_03 > 0)
        {
            value_03 -= 1;
            _val03.text = value_03.ToString();
        }
    }
    #endregion

    #region Confirm button logic
    public void ConfirmEvent()
    {
        if (value_01 == correctValue_01 && value_02 == correctValue_02 && value_03 == correctValue_03)
        {
            for (int i = 0; i < sectionDoor.Count; i++)
            {
                sectionDoor[i].GetComponent<Animator>().SetInteger("Open", 1);
            }
            audioManager.ObjectBegin(1);//play door creek
            sectionManager.masionPuzzle_F1_03 = true;
            phoneManager.NewMessageNotification();
            gameController.Save();
            SafeLockCanvasObj.SetActive(false);
            safeUIPanel.SetActive(false);
        }
        else
        {
            audioManager.ObjectBegin(4);//drum echo
            safeUIPanel.SetActive(false);
            incorrectInputNotice.SetActive(true);
        }
    }
    #endregion

    #region OnTriggerEnter & OnTriggerExit
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Safe")
            {
                safeUIPanel.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Safe")
            {
                safeUIPanel.SetActive(false);
                incorrectInputNotice.SetActive(false);
            }
        }
    }
    #endregion
}
