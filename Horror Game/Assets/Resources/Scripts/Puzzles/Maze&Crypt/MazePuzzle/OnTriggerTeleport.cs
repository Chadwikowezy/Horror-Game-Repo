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

    private void Teleport()
    {
        targetPrefab.transform.position = new Vector3(xPos,yPos,zPos);
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

            print("Collision");
        };
    }
}
