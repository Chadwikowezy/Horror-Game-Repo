using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerTranslation : MonoBehaviour
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

    private void TranslateBlock()
    {
        targetPrefab.transform.Translate(xPos, yPos, zPos);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            if (activated == false)
            {
                TranslateBlock();
                activated = true;
            }
            
            print("Collision");
        };
    }
}
