using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerInput : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject triggerPrefab;

    [SerializeField]
    private GameObject Sprite;

    public bool isActive = false;
    public bool activated = false;
    #endregion

    #region Triggers
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Sprite.SetActive(true);

        };
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Sprite.SetActive(false);
            
        };
    }
    #endregion
}
