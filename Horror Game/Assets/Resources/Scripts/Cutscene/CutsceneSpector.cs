using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CutsceneSpector : MonoBehaviour
{
    public bool chasingPlayer;
    public float changeSpeedWaitTime;
    public float runSpeed;
    public GameObject finalWaypoint;

    private bool changedSpeed;
    private float _timer;
    private NavMeshAgent _myAgent;
    private Animator _anim;
    private CutscenePlayer _player;

    private void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
        _player = FindObjectOfType<CutscenePlayer>();
        chasingPlayer = true;
    }
    private void Update()
    {
        _anim.SetFloat("Speed", _myAgent.velocity.magnitude);

        if (chasingPlayer)
            _myAgent.SetDestination(_player.transform.position);
        
        if (_timer < changeSpeedWaitTime && !changedSpeed)
            _timer += Time.deltaTime;
        else if (!changedSpeed)
        {
            _myAgent.speed = runSpeed;
            changedSpeed = true;
        }
    }
}
