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
    private GameObject brokenPhone;

    public AudioSource phoneDrop;

   [SerializeField]
    private bool activated = false;

    public GameObject Ambience_01,
                      Ambience_02;

    private SectionManager sectionManager;
    private GameController gameController;

    private SpectorToCrypt spectorToCrypt;

    #endregion

    IEnumerator FunctionDelay()
    {
        yield return new WaitForSeconds(0.2f);
        
    }

    #region Functions
    public void Start()
    {
        targetPrefab = GameObject.FindObjectOfType<PlayerMotor>().gameObject;
        sectionManager = FindObjectOfType<SectionManager>();
        gameController = FindObjectOfType<GameController>();
        spectorToCrypt = FindObjectOfType<SpectorToCrypt>();
    }
    private void Teleport()
    {
        AudioSource source = GetComponent<AudioSource>();
        targetPrefab.transform.position = destination.transform.position;
        phoneDrop.Play();
        Instantiate(brokenPhone, destination.gameObject.transform.position, Quaternion.identity);
        Ambience_01.SetActive(false);
        Ambience_02.SetActive(true);
        source.Play();

        sectionManager.mausoleumPuzzle = true;
        gameController.Save();
        spectorToCrypt.TeleportSpector();
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
