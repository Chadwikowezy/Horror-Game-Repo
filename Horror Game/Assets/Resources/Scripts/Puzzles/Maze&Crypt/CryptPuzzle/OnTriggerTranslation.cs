using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerTranslation : MonoBehaviour
{

    [SerializeField]
    private GameObject triggerPrefab;

    public GameObject targetPrefab;

    public GameObject rotateWall_01Bttn;

    [SerializeField]
    private float xPos;
    [SerializeField]
    private float yPos;
    [SerializeField]
    private float zPos;

    [SerializeField]
    public bool activated = false;

    public void TranslateBlock()
    {
        targetPrefab.transform.Translate(xPos, yPos, zPos);
    }

    public void RemoveWall_01()
    {
        targetPrefab.transform.Translate(xPos, yPos, zPos);
        rotateWall_01Bttn.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            if (activated == false)
            {
                //TranslateBlock();
                activated = true;
            }
            
            print("Collision");
        };
    }
}
