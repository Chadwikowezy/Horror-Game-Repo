using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerInput : MonoBehaviour
{
    [SerializeField]
    private GameObject triggerPrefab;

    [SerializeField]
    private GameObject Sprite;



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Sprite.SetActive(true);
            print("Collision");

        };
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    if (col.gameObject.GetComponent<OnTriggerTranslation>().activated == false)
                    {
                        col.gameObject.GetComponent<OnTriggerTranslation>().TranslateBlock();
                        Sprite.SetActive(false);
                    }
                    

                }
                    
            }

        };
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Sprite.SetActive(false);

        };
    }

}
