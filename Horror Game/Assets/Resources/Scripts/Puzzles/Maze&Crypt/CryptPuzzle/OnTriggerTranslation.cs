using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerTranslation : MonoBehaviour
{
    private Spector spector;

    public GameObject targetPrefab;

    public GameObject rotateWallBttn;

    private OnTriggerInput onTriggerInput;

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

    void Start()
    {
        spector = FindObjectOfType<Spector>();
        onTriggerInput = GetComponent<OnTriggerInput>();
        source = GetComponent<AudioSource>();
    }

    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(1);
        PlayAudio_WallMove();
    }

    public void TranslateBlock_01()
    {
        targetPrefab.transform.Translate(xPos, yPos, zPos);
    }
    
    public void RemoveWall_01()
    {
        targetPrefab.transform.Translate(xPos, yPos, zPos);
        rotateWallBttn.SetActive(false);
        spector.AlertPosition = transform.position;
        onTriggerInput.isActive = true;
    }
    public void RemoveWall_02()
    {
        targetPrefab.transform.Translate(xPos, yPos, zPos);
        rotateWallBttn.SetActive(false);
        spector.AlertPosition = transform.position;
        onTriggerInput.isActive = true;
    }
    public void RemoveWall_03()
    {
        targetPrefab.transform.Translate(xPos, yPos, zPos);
        rotateWallBttn.SetActive(false);
        spector.AlertPosition = transform.position;
        onTriggerInput.isActive = true;
    }

    public void PlayAudio_MetalClick()
    {
        source.clip = GetComponent<OnTriggerTranslation>().clip_01;
        source.Play();
        StartCoroutine("AudioDelay");
    }

    public void PlayAudio_WallMove()
    {
        source.clip = GetComponent<OnTriggerTranslation>().clip_02;
        source.Play(); 
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
