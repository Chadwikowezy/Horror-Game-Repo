using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpectorAnimController : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _myAgent;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _myAgent = GetComponentInParent<NavMeshAgent>();
    }
    private void Update()
    {
        _anim.SetFloat("Speed", _myAgent.velocity.magnitude);
    }
}
