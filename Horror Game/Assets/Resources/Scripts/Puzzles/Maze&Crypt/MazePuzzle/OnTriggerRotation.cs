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

    private Spector spector;

    [SerializeField]
    private float xRot;
    [SerializeField]
    private float yRot;
    [SerializeField]
    private float zRot;

    public float speed;

    [SerializeField]
    private Vector3 newRot;

    public AudioClip clip_01,
                     clip_02;

    public AudioSource source;

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
        if(targetPrefab.gameObject.transform.eulerAngles == newRot)
        {
            source.clip = GetComponent<OnTriggerRotation>().clip_01;
            source.Play();

        }

        else
        {
            spector.AlertPosition = transform.position;
        }
    }

    #endregion
}
