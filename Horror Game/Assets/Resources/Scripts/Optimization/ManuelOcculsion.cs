﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuelOcculsion : MonoBehaviour
{
    private Camera cam;
    private PlayerMotor player;
    //public List<GameObject> occlusionObjects = new List<GameObject>();

    [Header("!!First Floor!!")]
    public List<GameObject> entraceObjs = new List<GameObject>();
    public List<GameObject> masterBedroomObjs = new List<GameObject>();
    public List<GameObject> kitchen = new List<GameObject>();
    public List<GameObject> dinningRoom = new List<GameObject>();
    public List<GameObject> study = new List<GameObject>();
    public List<GameObject> livingArea = new List<GameObject>();
    public List<GameObject> raisedSittingArea = new List<GameObject>();
    public List<GameObject> gameRoom = new List<GameObject>();
    public List<GameObject> bath_02 = new List<GameObject>();
    public List<GameObject> bedroom_01 = new List<GameObject>();
    public List<GameObject> bedroom_02 = new List<GameObject>();
    public List<GameObject> bath_03 = new List<GameObject>();
    public List<GameObject> theatre = new List<GameObject>();
    public List<GameObject> bar = new List<GameObject>();
    public List<GameObject> doors = new List<GameObject>();
    public List<GameObject> glassDoors = new List<GameObject>();

    [Header("!!Second Floor!!")]
    public List<GameObject> f2_Bath_02 = new List<GameObject>();
    public List<GameObject> f2_MasterBed= new List<GameObject>();
    public List<GameObject> f2_Bath_01 = new List<GameObject>();
    public List<GameObject> f2_Bedroom_03 = new List<GameObject>();
    public List<GameObject> f2_Bedroom_02 = new List<GameObject>();
    public List<GameObject> f2_Bedroom_01 = new List<GameObject>();
    public List<GameObject> f2_Hallway = new List<GameObject>();

    void Start ()
    {
        cam = GetComponent<Camera>();
        player = FindObjectOfType<PlayerMotor>();       
    }

    void Update ()
    {
        FirstFloorCulling(entraceObjs);
        FirstFloorCulling(masterBedroomObjs);
        FirstFloorCulling(kitchen);
        FirstFloorCulling(dinningRoom);
        FirstFloorCulling(study);
        FirstFloorCulling(livingArea);
        FirstFloorCulling(raisedSittingArea);
        FirstFloorCulling(gameRoom);
        FirstFloorCulling(bath_02);
        FirstFloorCulling(bedroom_01);
        FirstFloorCulling(bedroom_02);
        FirstFloorCulling(bath_03);
        FirstFloorCulling(theatre);
        FirstFloorCulling(bar);
        FirstFloorCulling(doors);
        FirstFloorCulling(glassDoors);

        SecondFloorCulling(f2_Bath_02);
        SecondFloorCulling(f2_MasterBed);
        SecondFloorCulling(f2_Bath_01);
        SecondFloorCulling(f2_Bedroom_03);
        SecondFloorCulling(f2_Bedroom_02);
        SecondFloorCulling(f2_Bedroom_01);
        SecondFloorCulling(f2_Hallway);
        //OcclusionCulling();
    }

    void FirstFloorCulling(List<GameObject> colliderObjs)
    {
        foreach (GameObject colliderObj in colliderObjs)
        {
            if(colliderObj != null)
            {
                if (Vector3.Distance(colliderObj.transform.position, player.transform.position) > 30 || player.transform.position.y >= 6)
                {
                    colliderObj.SetActive(false);
                }
                else
                {
                    colliderObj.SetActive(true);
                    if (colliderObj.GetComponent<Collider>())
                    {
                        float localScaleToMultiply;
                        if (colliderObj.transform.localScale.z >= colliderObj.transform.localScale.x)
                        {
                            localScaleToMultiply = colliderObj.transform.localScale.z;
                        }
                        else if (colliderObj.transform.localScale.x > colliderObj.transform.localScale.z)
                        {
                            localScaleToMultiply = colliderObj.transform.localScale.x;
                        }
                        else
                        {
                            localScaleToMultiply = colliderObj.transform.localScale.y;
                        }
                        if (Vector3.Distance(colliderObj.transform.position, player.transform.position) < localScaleToMultiply * 5)
                        {
                            colliderObj.GetComponent<Collider>().enabled = true;
                        }
                        else
                        {
                            colliderObj.GetComponent<Collider>().enabled = false;
                        }
                    }
                }
            }
            
        }
    }

    void SecondFloorCulling(List<GameObject> colliderObjs)
    {
        foreach (GameObject colliderObj in colliderObjs)
        {
            if(colliderObj != null)
            {
                if (Vector3.Distance(colliderObj.transform.position, player.transform.position) > 30 || player.transform.position.y < 6)
                {
                    colliderObj.SetActive(false);
                }
                else
                {
                    colliderObj.SetActive(true);
                    if (colliderObj.GetComponent<Collider>())
                    {
                        float localScaleToMultiply;
                        if (colliderObj.transform.localScale.z >= colliderObj.transform.localScale.x)
                        {
                            localScaleToMultiply = colliderObj.transform.localScale.z;
                        }
                        else if (colliderObj.transform.localScale.x > colliderObj.transform.localScale.z)
                        {
                            localScaleToMultiply = colliderObj.transform.localScale.x;
                        }
                        else
                        {
                            localScaleToMultiply = colliderObj.transform.localScale.y;
                        }
                        if (Vector3.Distance(colliderObj.transform.position, player.transform.position) < localScaleToMultiply * 5)
                        {
                            colliderObj.GetComponent<Collider>().enabled = true;
                        }
                        else
                        {
                            colliderObj.GetComponent<Collider>().enabled = false;
                        }
                    }
                }
            }
            
        }
    }

    /*void OcclusionCulling()
    {
        foreach(GameObject occlusionObj in occlusionObjects)
        {
            Vector3 screenPoint = cam.WorldToViewportPoint(occlusionObj.transform.position);
            bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && 
                screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;          

            if (occlusionObj.GetComponent<Renderer>())
            {
                Renderer rend = occlusionObj.GetComponent<Renderer>();
                if (!onScreen)
                {
                    rend.enabled = false;
                }
                else
                {
                    rend.enabled = true;
                }
            }
            else
            {
                Renderer[] rends = occlusionObj.GetComponentsInChildren<Renderer>();
                foreach(Renderer rend in rends)
                {
                    if (!onScreen)
                    {
                        rend.enabled = false;
                    }
                    else
                    {
                        rend.enabled = true;
                    }
                }              
            }           
        }
    }*/
}
