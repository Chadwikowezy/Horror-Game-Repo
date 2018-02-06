using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGameCutscene : MonoBehaviour
{
    public GameObject player;
    public GameObject spector;
    public GameObject cam;

    public float rotateSpeed;

    [Space(10), Header("Look Targets")]
    public GameObject[] targets;

    [Space(10), Header("Wait Times")]
    public float[] waitTimes;

    private void Start()
    {
        StartCoroutine(startCutscene());
    }

    IEnumerator startCutscene()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            cam.GetComponent<PlayerCamera>().lookTarget = targets[i].transform;

            yield return new WaitForSeconds(waitTimes[i]);
        }
    }
}
