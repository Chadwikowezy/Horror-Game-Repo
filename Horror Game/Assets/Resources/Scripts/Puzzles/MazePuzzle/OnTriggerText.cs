using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerText : MonoBehaviour
{
    [SerializeField]
    private GameObject triggerPrefab; 
    [SerializeField]
    private GameObject targetPrefab; 
    [SerializeField]
    private GameObject SecondaryTargetPrefab; 

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            targetPrefab.SetActive(true);
            print("Collision");
            
        };
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            if (col.gameObject.GetComponent<PlayerMotor>().onPhone)
            {
                targetPrefab.SetActive(false);
                //phone ui
            }

            if (!col.gameObject.GetComponent<PlayerMotor>().onPhone)
            {
                //phone ui
                targetPrefab.SetActive(true);
            }

        };
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            targetPrefab.SetActive(false);
        };
    }

}
