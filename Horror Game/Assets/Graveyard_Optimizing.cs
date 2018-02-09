using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard_Optimizing : MonoBehaviour
{
    private Camera cam;
    private PlayerMotor player;

    public List<GameObject> graveyardObjects = new List<GameObject>();
    public List<GameObject> rockClusters = new List<GameObject>();

    void Start ()
    {
        cam = GetComponent<Camera>();
        player = FindObjectOfType<PlayerMotor>();
    }
	
	void Update ()
    {
        ObjectCulling(graveyardObjects);
        ObjectCulling(rockClusters);
    }

    void ObjectCulling(List<GameObject> colliderObjs)
    {
        foreach (GameObject colliderObj in colliderObjs)
        {
            if (colliderObj != null)
            {
                if (Vector3.Distance(colliderObj.transform.position, player.transform.position) > 30)
                {
                    colliderObj.SetActive(false);
                }
                else
                {
                    colliderObj.SetActive(true);
                    if (colliderObj.GetComponent<Collider>())
                    {
                        float localScaleToMultiply;
                        if (colliderObj.transform.localScale.z >= colliderObj.transform.localScale.x
                            && colliderObj.transform.localScale.z >= colliderObj.transform.localScale.y)
                        {
                            localScaleToMultiply = colliderObj.transform.localScale.z;
                        }
                        else if (colliderObj.transform.localScale.x >= colliderObj.transform.localScale.z
                            && colliderObj.transform.localScale.x >= colliderObj.transform.localScale.y)
                        {
                            localScaleToMultiply = colliderObj.transform.localScale.x;
                        }
                        else if (colliderObj.transform.localScale.y >= colliderObj.transform.localScale.z
                            && colliderObj.transform.localScale.y >= colliderObj.transform.localScale.z)
                        {
                            localScaleToMultiply = colliderObj.transform.localScale.y;
                        }
                        else
                        {
                            localScaleToMultiply = 10;
                        }
                        if (Vector3.Distance(colliderObj.transform.position, player.transform.position) < localScaleToMultiply * 10)
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
}
