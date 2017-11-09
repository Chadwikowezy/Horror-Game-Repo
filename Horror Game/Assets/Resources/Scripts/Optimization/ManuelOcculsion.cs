using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuelOcculsion : MonoBehaviour
{
    private Camera cam;
    private GameObject[] occlusionObjects;

	void Start ()
    {
        cam = GetComponent<Camera>();
        occlusionObjects = GameObject.FindGameObjectsWithTag("Occlusion");
    }
	
	void Update ()
    {
        OcclusionCulling();
    }

    void OcclusionCulling()
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
    }
}
