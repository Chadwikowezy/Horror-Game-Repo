using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public List<GameObject> firstFloorProps;
    public List<GameObject> secondFloorProps;

    public Actor actor;

    public bool currenFloorOne;

	void RecievedActorCall()
    {
        actor = FindObjectOfType<Actor>();

	}
	
	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SectionManager>())
        {
            currenFloorOne = !currenFloorOne;
            if(currenFloorOne == true)
            {
                for (int i = 0; i < secondFloorProps.Count; i++)
                {
                    secondFloorProps[i].SetActive(false);
                    firstFloorProps[i].SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < secondFloorProps.Count; i++)
                {
                    secondFloorProps[i].SetActive(true);
                    firstFloorProps[i].SetActive(false);
                }
            }
        }
    }
}
