using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CutscenePlayer : MonoBehaviour
{
    public Transform[] waypoints;

    private NavMeshAgent _myAgent;
    private Animator _anim;

    private void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _myAgent.SetDestination(waypoints[0].position);
        _anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        _anim.SetFloat("Speed", _myAgent.velocity.magnitude);
    }
}
