using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerTeleport : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject triggerPrefab;
    [SerializeField]
    private GameObject targetPrefab;
    [SerializeField]
    private GameObject destination;

    [SerializeField]
    private bool activated = false;

    public GameObject Ambience_01,
                      Ambience_02;

    #endregion

    IEnumerator FunctionDelay()
    {
        yield return new WaitForSeconds(0.2f);
        
    }

    #region Functions
    public void Start()
    {
        targetPrefab = GameObject.FindGameObjectWithTag("Player");
    }
    private void Teleport()
    {
        AudioSource source = GetComponent<AudioSource>();
        targetPrefab.transform.position = destination.transform.position;
        Ambience_01.SetActive(false);
        Ambience_02.SetActive(true);
        source.Play();
    }
    #endregion

    #region Triggers
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            if (activated == false)
            {
                Teleport();
                activated = true;
            }

        };
    }
    #endregion 
}
