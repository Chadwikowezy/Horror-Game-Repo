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
    private CutsceneCamera _cam;

    public bool Stoped
    {
        get { return _stoped; }
        set
        {
            if (value == true)
                _myAgent.speed = 0;
            else
                _myAgent.speed = moveSpeed;

            _stoped = value;
        }
    }

    private void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponentInChildren<Animator>();
        _cam = FindObjectOfType<CutsceneCamera>();
        _currentWaypoint = 0;

        if(waypoints.Length > 0)
            _myAgent.SetDestination(waypoints[_currentWaypoint].position);
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

    public void knockBack(Vector3 direction, float amount)
    {
        StartCoroutine(takeKnockBack(direction, amount));
    }

    public IEnumerator takeKnockBack(Vector3 direction, float amount)
    {
        GetComponentInChildren<Animator>().CrossFade("Jump Back",0.1f);

        float originalAcceleration = _myAgent.acceleration;

        moveSpeed = moveSpeed * 3.5f;
        _myAgent.destination = direction * amount;
        _myAgent.speed = 2;
        _myAgent.angularSpeed = 0;
        _myAgent.acceleration = 50;

        yield return new WaitForSeconds(2.667f);

        _myAgent.speed = moveSpeed;
        _myAgent.angularSpeed = 500;
        _myAgent.acceleration = originalAcceleration;

        if (_cam != null)
            _cam.lookTarget = null;
    }
}
