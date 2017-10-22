﻿using System.Collections;
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
    public GameObject sectionDoor;
    private GameController gameController;
    #endregion

    #region Start
    void Start ()
    {
        if(actor == null)
        {
            actor = FindObjectOfType<Actor>();
        }
        safeUIPanel.SetActive(false);
        incorrectInputNotice.SetActive(false);

        GenerateValues();
        gameController = FindObjectOfType<GameController>();
    }
    #endregion

    #region generating values and proceduraly placing numbers
    void GenerateValues()
    {
        if (actor.data.masionPuzzle_F1_03 == false)
        {
            SafeLockCanvasObj.SetActive(true);
            correctValue_01 = Random.Range(0, 10);
            correctValue_02 = Random.Range(0, 10);
            correctValue_03 = Random.Range(0, 10);

            while (spawnPoint01 == spawnPoint02 || spawnPoint01 == spawnPoint03 || spawnPoint01 == spawnPoint04)
            {
                spawnPoint01 = (Random.Range(0, 5) + Random.Range(0, 6));
            }
            while (spawnPoint02 == spawnPoint01 || spawnPoint02 == spawnPoint03 || spawnPoint02 == spawnPoint04)
            {
                spawnPoint02 = (Random.Range(0, 5) + Random.Range(0, 6));
            }
            while (spawnPoint03 == spawnPoint01 || spawnPoint03 == spawnPoint02 || spawnPoint03 == spawnPoint04)
            {
                spawnPoint03 = (Random.Range(0, 5) + Random.Range(0, 6));
            }
            while (spawnPoint04 == spawnPoint01 || spawnPoint04 == spawnPoint02 || spawnPoint04 == spawnPoint03)
            {
                spawnPoint04 = (Random.Range(0, 5) + Random.Range(0, 6));
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

            Debug.Log("Value01: " + correctValue_01);
            Debug.Log("Value02: " + correctValue_02);
            Debug.Log("Value03: " + correctValue_03);

        }
        else if (actor.data.masionPuzzle_F1_03 == true)
        {
            SafeLockCanvasObj.SetActive(false);
            sectionDoor.SetActive(false);
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
        if(value_01 > 1)
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
        if (value_02 > 1)
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
        if (value_03 > 1)
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
            actor.data.masionPuzzle_F1_03 = true;
            sectionDoor.SetActive(false);
            gameController.Save();
            SafeLockCanvasObj.SetActive(false);
            safeUIPanel.SetActive(false);
            Debug.Log("FML....");
        }
        else
        {
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
