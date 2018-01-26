using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Graveyard_StartGame : MonoBehaviour
{
    public float detectionDistance;
    public GameObject[] doors;
    public GameObject monster;

    [Header("Flickering Light")]
    public Light[] flickeringLights;
    public int numOfFlickers;
    public float minWaitTime;
    public float maxWaitTime;

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

        StartCoroutine(flickerLight());

        yield return null;
    }

    IEnumerator flickerLight()
    {
        if (numOfFlickers % 2 == 0)
            numOfFlickers++;

        for (int i = 0; i < numOfFlickers; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));

            foreach (Light light in flickeringLights)
                light.enabled = !light.enabled;
        }
    }
}
