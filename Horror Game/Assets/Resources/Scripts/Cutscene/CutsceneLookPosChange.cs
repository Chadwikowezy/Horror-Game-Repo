using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneLookPosChange : MonoBehaviour
{
    public GameObject player;
    public GameObject currentCamera;
    public float detectionDistance;
    public Transform lookPosition;

    private bool _looked;

    private void Update()
    {
        if ((player.transform.position - transform.position).magnitude < detectionDistance && !_looked)
        {
            currentCamera.GetComponent<CutsceneCamera>().lookTarget = lookPosition;
            _looked = true;
        }
        else if ((player.transform.position - transform.position).magnitude > detectionDistance && _looked)
        {
            currentCamera.GetComponent<CutsceneCamera>().lookTarget = null;
            enabled = false;
        }
    }
}
