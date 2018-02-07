using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGameCutscene : MonoBehaviour
{
    public GameObject[] waypoints;

    public GameObject player;
    public GameObject spector;
    public GameObject cam;

    [Space(10), Header("Look Targets")]
    public GameObject[] targets;

    [Space(10), Header("Wait Times")]
    public float[] waitTimes;

    [Space(10), Header("Animators")]
    public Animator playerAnim;
    public Animator spectorAnim;

    private void Start()
    {
        StartCoroutine(startCutscene());
    }

    IEnumerator startCutscene()
    {
        PlayerCamera _playerCam = cam.GetComponent<PlayerCamera>();

        for (int i = 0; i < targets.Length; i++)
        {
            _playerCam.lookTarget = targets[i].transform;

            if (i == 1)
            {
                CutscenePlayer _player = player.GetComponent<CutscenePlayer>();
                _player.Stoped = true;

                yield return new WaitForSeconds(1f);

                _player.knockBack(player.transform.position + (waypoints[1].transform.position - player.transform.position), 1);
                _player.enabled = false;

                yield return new WaitForSeconds(13f);

                _player.moveSpeed = 2;
                _player.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 2;
                _player.enabled = true;
            }

            yield return new WaitForSeconds(waitTimes[i]);
        }
    }
}
