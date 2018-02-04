using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OPCS_Player : MonoBehaviour
{
    public int controlSpeed;
    public List<Transform> pathNodes = new List<Transform>();
    public int nextPathNode;
    public NavMeshAgent myNav;
    private Animator anim;

    public GameObject buttonEvent;
    public bool canPath = true;
    public bool footprintsPlay = true;
    public AudioSource audio;

    void Start ()
    {
        nextPathNode = 0;
        myNav = GetComponent<NavMeshAgent>();
        myNav.SetDestination(pathNodes[nextPathNode].position);
        anim = GetComponentInChildren<Animator>();
    }
	
	void LateUpdate ()
    {
        SetNextPos();
        if(myNav.speed > 0)
        {
            if(footprintsPlay == true)
            {
                audio.Play();
                footprintsPlay = false;
            }
        }
    }

    void SetNextPos()
    {
        if((myNav.destination - transform.position).magnitude < 1f && nextPathNode < pathNodes.Count - 1)
        {
            if (canPath == true)
            {
                nextPathNode++;
                myNav.SetDestination(pathNodes[nextPathNode].position);

                if (nextPathNode == 6)
                {
                    //Debug.Log(pathNodes[nextPathNode].name);
                    audio.Stop();
                    canPath = false;
                    buttonEvent.SetActive(true);
                }
            }
        }
        anim.SetFloat("Speed", myNav.velocity.magnitude);
    }
}
