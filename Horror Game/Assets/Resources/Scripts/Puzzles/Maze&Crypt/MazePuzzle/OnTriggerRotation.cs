using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerRotation : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject triggerPrefab;
    [SerializeField]
    private GameObject targetPrefab;
    [SerializeField]
    private GameObject SecondaryTargetPrefab;
    [SerializeField]
    private GameObject inputSprite;
    [SerializeField]
    private GameObject inputSprite02;
    [SerializeField]
    private GameObject inputTrigger;
    public GameObject item;

    private Spector spector;
    private Rotation rotation;

    [SerializeField]
    private float xRot;
    [SerializeField]
    private float yRot;
    [SerializeField]
    private float zRot;

    public float speed;

    [SerializeField]
    private Vector3 newRot;

    public AudioClip clip_01,clip_02;

    public AudioSource source;

    public Animator anim;

    public bool activated = false;
    #endregion

    #region Coroutines
    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(.2f);
        PlayAudio_02();
        yield return new WaitForSeconds(1);
    }
    #endregion

    #region Functions
    public void Start()
    {
        spector = FindObjectOfType<Spector>();
        rotation = targetPrefab.gameObject.GetComponent<Rotation>();

    }
    public void PlayAudio_01()
    {
        source.clip = GetComponent<OnTriggerRotation>().clip_01;
        source.Play();
        StartCoroutine("AudioDelay");
    }

    public void PlayAudio_02()
    {
        source.clip = GetComponent<OnTriggerRotation>().clip_02;
        source.Play();
    }

    public void RotateBlock()
    {
        targetPrefab.transform.Rotate(xRot, yRot, zRot);
        SecondaryTargetPrefab.transform.Rotate(xRot, yRot, zRot);
    }

    public void RotateBlock_02()
    {
        targetPrefab.transform.Rotate(xRot, yRot, zRot);
    }

    public void ConfirmBlock()
    {
        if (rotation.timesRotated == rotation.correctRotation)  
        {
            PlayAudio_01();
            inputTrigger.SetActive(false);
            anim.Play("CoffinOpen");
            item.SetActive(true);
            inputTrigger.SetActive(false);
            inputSprite02.SetActive(false);
            inputSprite.SetActive(false);
        }

        else
        {
            spector.AlertPosition = transform.position;
        }
    }

    #endregion
}
