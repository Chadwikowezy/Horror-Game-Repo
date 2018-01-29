using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject triggerPrefab;
    [SerializeField]
    private GameObject targetPrefab;
    [SerializeField]
    private GameObject SecondaryTargetPrefab;

    [SerializeField]
    private float xRot;
    [SerializeField]
    private float yRot;
    [SerializeField]
    private float zRot;

    public AudioClip clip_01,
                     clip_02;

    public AudioSource source;

    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(1);
        PlayAudio_Whispering();
    }

    public void PlayAudio_DrumEcho()
    {
        source.clip = GetComponent<OnTriggerRotation>().clip_01;
        source.Play();
        StartCoroutine("AudioDelay");
    }

    public void PlayAudio_Whispering()
    {
        source.clip = GetComponent<OnTriggerRotation>().clip_02;
        source.Play();
    }

    public void RotateBlock()
    {
        targetPrefab.transform.Rotate(xRot, yRot, zRot);
        SecondaryTargetPrefab.transform.Rotate(xRot, yRot, zRot);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //RotateBlock();
            //print("Collision");
        };
    }
}
