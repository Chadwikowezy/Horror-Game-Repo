using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Graveyard_StartGame : MonoBehaviour
{
    public float detectionDistance;
    public GameObject[] doors;
    public GameObject monster;

    private GameObject _player;

    private void Start()
    {
        _player = FindObjectOfType<CutscenePlayer>().gameObject;
    }
    private void Update()
    {
        if ((_player.transform.position - transform.position).magnitude < detectionDistance)
            StartCoroutine(activateGameplay());
    }

    IEnumerator activateGameplay ()
    {
        CutsceneSpector spector = monster.GetComponent<CutsceneSpector>();

        spector.chasingPlayer = false;
        monster.GetComponent<NavMeshAgent>().SetDestination(spector.finalWaypoint.transform.position);

        foreach (GameObject door in doors)
            door.transform.rotation = Quaternion.Euler(new Vector3(0, 180,0));

        yield return null;
    }
}
