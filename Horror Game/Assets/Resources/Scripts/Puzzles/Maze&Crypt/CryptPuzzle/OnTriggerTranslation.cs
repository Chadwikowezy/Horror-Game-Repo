using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerTranslation : MonoBehaviour
{
    #region Variables
    private Spector spector;

    public GameObject targetPrefab;
    [SerializeField]
    private GameObject inputTrigger;
    [SerializeField]
    private GameObject inputSprite;

    [SerializeField]
    private float xPos;
    [SerializeField]
    private float yPos;
    [SerializeField]
    private float zPos;

    [SerializeField]
    public bool activated = false;

    public AudioClip clip_01,
                     clip_02;

    public AudioSource source;
    #endregion
  
    #region Coroutines
    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(1);
        PlayAudio_02();
    }
    #endregion

    #region Functions

    void Start()
    {
        spector = FindObjectOfType<Spector>();
        source = GetComponent<AudioSource>();
    }

    public void TranslateBlock_01()
    {
        targetPrefab.transform.Translate(xPos, yPos, zPos);
    }
    
    public void RemoveWall_01()
    {
        inputTrigger.SetActive(false);
        inputSprite.SetActive(false);
        targetPrefab.transform.Translate(xPos, yPos, zPos);
        spector.AlertPosition = transform.position;
        PlayAudio_01();
    }
    public void RemoveWall_02()
    {
        inputTrigger.SetActive(false);
        inputSprite.SetActive(false);
        targetPrefab.transform.Translate(xPos, yPos, zPos);
        spector.AlertPosition = transform.position;
        PlayAudio_01();
    }
    public void RemoveWall_03()
    {
        inputTrigger.SetActive(false);
        inputSprite.SetActive(false);
        targetPrefab.transform.Translate(xPos, yPos, zPos);
        spector.AlertPosition = transform.position;
        PlayAudio_01();
    }

    public void PlayAudio_01()
    {
        source.clip = GetComponent<OnTriggerTranslation>().clip_01;
        source.Play();
        StartCoroutine("AudioDelay");
    }

    public void PlayAudio_02()
    {
        source.clip = GetComponent<OnTriggerTranslation>().clip_02;
        source.Play(); 
    }
    #endregion

}
