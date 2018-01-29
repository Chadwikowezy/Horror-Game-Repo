using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerTeleport : MonoBehaviour
{

    [SerializeField]
    private GameObject triggerPrefab;
    [SerializeField]
    private GameObject targetPrefab;

    [SerializeField]
    private float xPos;
    [SerializeField]
    private float yPos;
    [SerializeField]
    private float zPos;

    [SerializeField]
    private bool activated = false;

    public GameObject Ambience_01,
                      Ambience_02;

    //public AudioClip clip_01;
                    
    //public AudioSource source;

    private void Teleport()
    {
        targetPrefab.transform.position = new Vector3(xPos,yPos,zPos);
        //source.clip = GetComponent<OnTriggerTeleport>().clip_01;
        Ambience_01.SetActive(false);
        Ambience_02.SetActive(true);
        //source.Play();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            if (activated == false)
            {
                Teleport();
                activated = true;
            }

            //print("Collision");
        };
    }
}
