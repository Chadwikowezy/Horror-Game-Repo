using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spector : MonoBehaviour
{
    //Variables
    public GameObject head;
    public AnimationClip attackAnim;

    public float walkSpeed;
    public float runSpeed;
    public float waypointDistance;
    public float idleTime;
    public float alertedDuration;
    public float detectionDistance;
    public float attackDistance;
    public float attackCooldown;

    private bool _attacking;
    private string _playerTag;
    private MonsterStates _previousState;
    private MonsterStates _currentState;
    private Vector3 _alertPosition;
    private NavMeshAgent _myAgent;
    private GameObject _player;
    private AudioManager _audioManager;
    private WaitForEndOfFrame _frameWait;

    private InsanityManager insanityManager;
    
    //Properties
    public MonsterStates PreviousState
    {
        get { return _previousState; }
    }
    public MonsterStates CurrentState
    {
        get { return _currentState; }
        set
        {
            _previousState = _currentState;
            _currentState = value;
            moveCharacter();
        }
    }
    public Vector3 AlertPosition
    {
        get { return _alertPosition; }
        set
        {
            _alertPosition = value;

            CurrentState = MonsterStates.Alerted;
        }
    }

    //MonoBehaviour
    private void Start()
    {
        _myAgent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerMotor>().gameObject;
        _playerTag = _player.tag;
        _audioManager = FindObjectOfType<AudioManager>();
        _frameWait = new WaitForEndOfFrame();
        insanityManager = FindObjectOfType<InsanityManager>();
        CurrentState = MonsterStates.Idle;   
    }
    private void Update()
    {
        detectPlayer();
    }

    //Functions
    void moveCharacter()
    {
        if (CurrentState == MonsterStates.Idle)
            StartCoroutine(idle());
        else if (CurrentState == MonsterStates.Patrol)
            StartCoroutine(patrol());
        else if (CurrentState == MonsterStates.Alerted)
            StartCoroutine(alerted());
        else if (CurrentState == MonsterStates.Chasing)
            StartCoroutine(chasing());
        else if (CurrentState == MonsterStates.Attacking)
            StartCoroutine(Attacking());
    }
    void changeMoveState()
    {
        float randomNumber = Random.Range(0f, 1f);

        if (CurrentState == MonsterStates.Idle || CurrentState == MonsterStates.Patrol || CurrentState == MonsterStates.Alerted)
        {
            if (randomNumber < 0.25f)
                CurrentState = MonsterStates.Idle;
            else
                CurrentState = MonsterStates.Patrol;
        }
    }
    void detectPlayer()
    {
        if (_attacking)
            return;

        if ((transform.position - _player.transform.position).magnitude < detectionDistance && _currentState != MonsterStates.Chasing)
        {
            Ray ray = new Ray(head.transform.position, _player.transform.position - head.transform.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, detectionDistance))
                if (hit.transform.gameObject.CompareTag(_playerTag))
                    CurrentState = MonsterStates.Chasing;
        }
    }
    void setRandomWaypoint(Vector3 originPosition)
    {
        Vector3 randomPosition = originPosition + Random.onUnitSphere * waypointDistance;
        NavMeshHit hit;

        randomPosition.y = transform.position.y;

        if (NavMesh.SamplePosition(randomPosition, out hit, 0.1f, NavMesh.AllAreas))
            _myAgent.SetDestination(hit.position);
    }

    //Corutines
    IEnumerator idle()
    {
        float randomNumber = Random.Range(0f, 1f);
        float timeElapsed = 0;

        _myAgent.SetDestination(transform.position);

        while (CurrentState == MonsterStates.Idle && timeElapsed < idleTime)
        {
            timeElapsed += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        if (CurrentState != MonsterStates.Idle)
            yield return null;
        else
            changeMoveState();
    }
    IEnumerator patrol()
    {
        _myAgent.speed = walkSpeed;
        setRandomWaypoint(transform.position);

        while ((transform.position - _myAgent.destination).magnitude > 0.33f && CurrentState == MonsterStates.Patrol)
        {
            yield return new WaitForEndOfFrame();
        }

        if (CurrentState != MonsterStates.Patrol)
            yield return null;
        else
            changeMoveState();
    }
    IEnumerator alerted()
    {
        bool reachedAlertPos = false;
        float timeElapsed = 0;

        _myAgent.speed = runSpeed;
        _myAgent.SetDestination(_alertPosition);
        
        while (CurrentState == MonsterStates.Alerted && timeElapsed < alertedDuration)
        {
            if (reachedAlertPos)
                timeElapsed += Time.deltaTime;

            if (transform.position == _myAgent.destination)
            {
                reachedAlertPos = true;
                _myAgent.speed = walkSpeed;
                setRandomWaypoint(_alertPosition);
            }
            yield return new WaitForEndOfFrame();
        }

        if (CurrentState != MonsterStates.Alerted)
            yield return null;

        changeMoveState();
    }
    IEnumerator chasing()
    {
        _audioManager.SpectorBeginSound(1);
        _myAgent.speed = runSpeed;

        while (_currentState == MonsterStates.Chasing)
        {
            Ray ray = new Ray(head.transform.position, _player.transform.position - head.transform.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, detectionDistance))
            {
                if (hit.transform.gameObject.CompareTag(_playerTag))
                {
                    _myAgent.SetDestination(_player.transform.position);

                    if ((transform.position - _player.transform.position).magnitude < attackDistance)
                        CurrentState = MonsterStates.Attacking;
                }
                else
                {
                    _alertPosition = _player.transform.position;
                    CurrentState = MonsterStates.Alerted;
                }
            }

            yield return _frameWait;
        }
    }
    IEnumerator Attacking()
    {
        if(insanityManager.CurrentInsanity < insanityManager.maxInsanity)
        {
            _audioManager.SpectorBeginSound(0);//scream sound
            _attacking = true;
            _myAgent.SetDestination(transform.position);
            _myAgent.speed = 0;
            _player.GetComponent<CameraMotor>().MonsterAttackEffect();
            GetComponentInChildren<Animator>().CrossFade("Spector Attack", 0.25f);

            yield return new WaitForSeconds(attackAnim.length);

            _myAgent.speed = runSpeed;
            _myAgent.SetDestination(-transform.forward * 5);
            StartCoroutine(resetAttack());
        } 
    }
    IEnumerator resetAttack()
    {
        yield return new WaitForSeconds(attackCooldown);

        _attacking = false;
        CurrentState = MonsterStates.Patrol;
    }
}
