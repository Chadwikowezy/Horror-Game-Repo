using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpectorToCrypt : MonoBehaviour
{
    private Spector spector;

	void Start ()
    {
        spector = FindObjectOfType<Spector>();
    }
	
	public void TeleportSpector()
    {
        spector.GetComponent<NavMeshAgent>().Warp(transform.position);
    }
}
