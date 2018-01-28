using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerLerp : MonoBehaviour
{

    [SerializeField]
    private GameObject triggerPrefab;
    [SerializeField]
    private GameObject targetPrefab;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float xRot;
    [SerializeField]
    private float yRot;
    [SerializeField]
    private float zRot;

    [SerializeField]
    private Vector3 rot; 

    private void LerpRotation()
    {
        targetPrefab.transform.Rotate(targetPrefab.transform.position, zRot);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            LerpRotation();
            print("Collision");
        };
    }
}
