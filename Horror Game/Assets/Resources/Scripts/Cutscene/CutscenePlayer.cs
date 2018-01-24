using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CutscenePlayer : MonoBehaviour
{
    public float moveSpeed;
    public Transform[] waypoints;

    private bool _stoped;
    private int _currentWaypoint;
    private NavMeshAgent _myAgent;
    private Animator _anim;

    public bool Stoped
    {
        get { return _stoped; }
        set
        {
            if (value == true)
                _myAgent.speed = 0;
            else
                _myAgent.speed = moveSpeed;
        }
    }

    private void Start()
    {
        _currentWaypoint = 0;
        _myAgent = GetComponent<NavMeshAgent>();
        _myAgent.SetDestination(waypoints[_currentWaypoint].position);
        _anim = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if ((_myAgent.destination - transform.position).magnitude < 1f  && _currentWaypoint < waypoints.Length - 1)
        {
            _currentWaypoint++;
            _myAgent.SetDestination(waypoints[_currentWaypoint].position);
        }

        _anim.SetFloat("Speed", _myAgent.velocity.magnitude);
    }
}
