using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard_CutsceneManager : MonoBehaviour
{
    public GameObject mausoleum;
    public GameObject largeTombstone;
    public GameObject player;
    public GameObject monster;

    private CutsceneCamera _cutsceneCamera;
    private CutscenePlayer _player;

    private void Start()
    {
        _cutsceneCamera = FindObjectOfType<CutsceneCamera>();
        _player = player.GetComponent<CutscenePlayer>();

        StartCoroutine(sceneIntro());
    }

    IEnumerator sceneIntro()
    {
        _cutsceneCamera.lookTarget = mausoleum.transform;

        yield return new WaitForSeconds(2f);

        _cutsceneCamera.lookTarget = largeTombstone.transform;
        _player.enabled = true;

        yield return new WaitForSeconds(5f);

        _cutsceneCamera.lookTarget = null;
    }
}
