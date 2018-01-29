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

    private void RotateBlock()
    {
        targetPrefab.transform.Rotate(xRot, yRot, zRot);
        SecondaryTargetPrefab.transform.Rotate(xRot, yRot, zRot);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            RotateBlock();
            print("Collision");
        };
    }
}
