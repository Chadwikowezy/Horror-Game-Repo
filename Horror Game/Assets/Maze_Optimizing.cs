using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze_Optimizing : MonoBehaviour
{
    private Camera cam;
    private PlayerMotor player;

    public List<GameObject> mazeBorderPieces = new List<GameObject>();
    public List<GameObject> MazeInnerPieces = new List<GameObject>();
    public List<GameObject> mausoleums = new List<GameObject>();
    public List<GameObject> objectPieces = new List<GameObject>();

    public List<GameObject> cryptPieces = new List<GameObject>();

    void Start ()
    {
        cam = GetComponent<Camera>();
        player = FindObjectOfType<PlayerMotor>();
	}

	void Update ()
    {
        HedgeCulling(mazeBorderPieces);
        HedgeCulling(MazeInnerPieces);
        ObjectCulling(objectPieces);
        MausoleumCull(mausoleums);
        CryptCulling(cryptPieces);
    }

    void HedgeCulling(List<GameObject> colliderObjs)
    {
        foreach (GameObject colliderObj in colliderObjs)
        {
            if (colliderObj != null)
            {
                if (Vector3.Distance(colliderObj.transform.position, player.transform.position) > 90 || player.transform.position.y < 0)
                {
                    colliderObj.SetActive(false);
                }
                else
                {
                    colliderObj.SetActive(true);                    
                }
            }

        }
    }

    void ObjectCulling(List<GameObject> colliderObjs)
    {
        foreach (GameObject colliderObj in colliderObjs)
        {
            if (colliderObj != null)
            {
                if (Vector3.Distance(colliderObj.transform.position, player.transform.position) > 25 || player.transform.position.y < 0)
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

    void MausoleumCull(List<GameObject> colliderObjs)
    {
        foreach (GameObject colliderObj in colliderObjs)
        {
            if (colliderObj != null)
            {
                if (Vector3.Distance(colliderObj.transform.position, player.transform.position) > 40 || player.transform.position.y < 0)
                {
                    colliderObj.SetActive(false);
                }
                else
                {
                    colliderObj.SetActive(true);                    
                }
            }

        }
    }

    void CryptCulling(List<GameObject> colliderObjs)
    {
        foreach (GameObject colliderObj in colliderObjs)
        {
            if (colliderObj != null)
            {
                if (Vector3.Distance(colliderObj.transform.position, player.transform.position) > 30 || player.transform.position.y >= 0)
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
