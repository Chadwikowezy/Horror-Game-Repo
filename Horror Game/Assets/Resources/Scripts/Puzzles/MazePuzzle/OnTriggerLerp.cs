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
    private float torque;

    private void LerpRotation()
    {
        Quaternion rot = transform.rotation;
        Quaternion newRot = Quaternion.Euler(0, 0, 45);
        transform.rotation = Quaternion.RotateTowards(rot, newRot, Time.deltaTime * torque);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            LerpRotation();
            print("Collision");
        };
    }
}
