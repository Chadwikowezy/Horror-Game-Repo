using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Graveyard_StartGame : MonoBehaviour
{
    public AudioClip[] clips;

    public float detectionDistance;
    public GameObject[] doors;
    public GameObject monster;

    [Header("Flickering Light")]
    public Light[] flickeringLights;
    public int numOfFlickers;
    public float minWaitTime;
    public float maxWaitTime;

    private bool _gameActive;
    private GameObject _player;

    private void Start()
    {
        _player = FindObjectOfType<CutscenePlayer>().gameObject;
    }
    private void Update()
    {
        if ((_player.transform.position - transform.position).magnitude < detectionDistance && !_gameActive)
        {
            activateGameplay();
            _gameActive = true;
        }
    }

    void activateGameplay()
    {
        CutsceneSpector spector = monster.GetComponent<CutsceneSpector>();

        spector.chasingPlayer = false;
        monster.GetComponent<NavMeshAgent>().SetDestination(spector.finalWaypoint.transform.position);

        foreach (GameObject door in doors)
            door.transform.rotation = Quaternion.Euler(new Vector3(0, 180,0));

        StartCoroutine(flickerLight());
    }

    IEnumerator flickerLight()
    {
        AudioSource source = GetComponent<AudioSource>();

        yield return new WaitForSeconds(3f);

        if (numOfFlickers % 2 == 0)
            numOfFlickers++;

        for (int i = 0; i < numOfFlickers; i++)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            GetComponent<AudioSource>().Play();

            foreach (Light light in flickeringLights)
                light.enabled = !light.enabled;
        }
    }
}
