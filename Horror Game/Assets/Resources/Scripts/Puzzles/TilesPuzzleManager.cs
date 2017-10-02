﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilesPuzzleManager : MonoBehaviour
{
    public GameObject[] tileObjects;

    public Transform[] spawnLocations;
    private int spawnPoint_01, spawnPoint_02, spawnPoint_03, spawnPoint_04, spawnPoint_05;

    public Image[] toolUISlots;
    public Sprite transparentEmpty;

    private ToolCollect toolCollect;

    private Actor actor;
    
    public GameObject sectionDoor;

    private int point_01, point_02, point_03, point_04;

    void Start ()
    {
        if (sectionDoor == null)
        {
            sectionDoor = GameObject.Find("SectionDoor_02");
        }

        if (actor == null)
        {
            actor = FindObjectOfType<Actor>();
        }
        GenerateTiles();     
    }

    void GenerateTiles()
    {
        if (actor.data.masionPuzzle_F1_02 == false)
        {
            toolCollect = FindObjectOfType<ToolCollect>();
      
            sectionDoor.SetActive(true);
            while (spawnPoint_01 == spawnPoint_02 || spawnPoint_01 == spawnPoint_03 ||
                spawnPoint_01 == spawnPoint_04 || spawnPoint_01 == spawnPoint_05)
            {
                spawnPoint_01 = (Random.Range(0, 6) + Random.Range(0, 7));
                point_01 = spawnPoint_01;
            }
            while (spawnPoint_02 == spawnPoint_01 || spawnPoint_02 == spawnPoint_03 || 
                spawnPoint_02 == spawnPoint_04 || spawnPoint_02 == spawnPoint_05)
            {
                spawnPoint_02 = (Random.Range(0, 6) + Random.Range(0, 7));
                point_02 = spawnPoint_02;
            }
            while (spawnPoint_03 == spawnPoint_01 || spawnPoint_03 == spawnPoint_02 || 
                spawnPoint_03 == spawnPoint_04 || spawnPoint_03 == spawnPoint_05)
            {
                spawnPoint_03 = (Random.Range(0, 6) + Random.Range(0, 7));
                point_03 = spawnPoint_03;
            }
            while (spawnPoint_04 == spawnPoint_01 || spawnPoint_04 == spawnPoint_02 ||
                spawnPoint_04 == spawnPoint_03 || spawnPoint_04 == spawnPoint_05)
            {
                spawnPoint_04 = (Random.Range(0, 6) + Random.Range(0, 7));
                point_04 = spawnPoint_04;
            }
            while (spawnPoint_05 == spawnPoint_01 || spawnPoint_05 == spawnPoint_02 ||
                spawnPoint_05 == spawnPoint_03 || spawnPoint_05 == spawnPoint_04)
            {
                spawnPoint_04 = (Random.Range(0, 6) + Random.Range(0, 7));
            }

            GameObject tile01 = Instantiate(tileObjects[0], spawnLocations[spawnPoint_01].position, 
                spawnLocations[spawnPoint_01].rotation);
            GameObject tile02 = Instantiate(tileObjects[1], spawnLocations[spawnPoint_02].position, 
                spawnLocations[spawnPoint_02].rotation);
            GameObject tile03 = Instantiate(tileObjects[2], spawnLocations[spawnPoint_03].position, 
                spawnLocations[spawnPoint_03].rotation);
            GameObject tile04 = Instantiate(tileObjects[3], spawnLocations[spawnPoint_04].position, 
                spawnLocations[spawnPoint_04].rotation);
        }
        else
        {
            sectionDoor.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void ResetTiles()
    {       
        while (spawnPoint_01 == spawnPoint_02 || spawnPoint_01 == spawnPoint_03 ||
                spawnPoint_01 == spawnPoint_04 || spawnPoint_01 == spawnPoint_05)
        {
            spawnPoint_01 = (Random.Range(0, 6) + Random.Range(0, 7));
            point_01 = spawnPoint_01;
        }
        while (spawnPoint_02 == spawnPoint_01 || spawnPoint_02 == spawnPoint_03 ||
                 spawnPoint_02 == spawnPoint_04 || spawnPoint_02 == spawnPoint_05)
        {
            spawnPoint_02 = (Random.Range(0, 6) + Random.Range(0, 7));
            point_02 = spawnPoint_02;
        }
        while (spawnPoint_03 == spawnPoint_01 || spawnPoint_03 == spawnPoint_02 ||
                 spawnPoint_03 == spawnPoint_04 || spawnPoint_03 == spawnPoint_05)
        {
            spawnPoint_03 = (Random.Range(0, 6) + Random.Range(0, 7));
            point_03 = spawnPoint_03;
        }
        while (spawnPoint_04 == spawnPoint_01 || spawnPoint_04 == spawnPoint_02 ||
                spawnPoint_04 == spawnPoint_03 || spawnPoint_04 == spawnPoint_05)
        {
            spawnPoint_04 = (Random.Range(0, 6) + Random.Range(0, 7));
            point_04 = spawnPoint_04;
        }
        while (spawnPoint_05 == spawnPoint_01 || spawnPoint_05 == spawnPoint_02 ||
                spawnPoint_05 == spawnPoint_03 || spawnPoint_05 == spawnPoint_04)
        {
            spawnPoint_04 = (Random.Range(0, 6) + Random.Range(0, 7));
        }

        ToolsManager toolsManager = FindObjectOfType<ToolsManager>();

        GameObject tile01 = Instantiate(tileObjects[0],
            spawnLocations[spawnPoint_01].position, spawnLocations[spawnPoint_01].rotation);
        GameObject tile02 = Instantiate(tileObjects[1],
            spawnLocations[spawnPoint_02].position, spawnLocations[spawnPoint_02].rotation);
        GameObject tile03 = Instantiate(tileObjects[2],
            spawnLocations[spawnPoint_03].position, spawnLocations[spawnPoint_03].rotation);
        GameObject tile04 = Instantiate(tileObjects[3],
            spawnLocations[spawnPoint_04].position, spawnLocations[spawnPoint_04].rotation);
    }
}
