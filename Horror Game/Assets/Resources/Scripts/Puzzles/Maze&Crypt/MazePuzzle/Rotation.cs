using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject triggerPrefab;
    [SerializeField]
    private GameObject inputTrigger;
    [SerializeField]
    private GameObject inputSprite;
    public GameObject triggerObj;

    private ToolsManager toolManager;
    public AudioSource source;

    [Range(0,1)]
    public float speed;

    private float minAngle = 0.0F;
    private float maxAngle = 90.0F;
    public float value;

    public int correctRotation = 0;
    private int min = 0;
    private int max = 7;
    public int timesRotated = 0;

    public int doorReq = 0;

    public Vector3 rot,
                newRot;

    private bool hasFinishedLooped = true;

    private bool rotated = false;

    public Quaternion resetTargetRotation;
    public Vector3 resetLocalRotation;
    #endregion

    #region Coroutines
    IEnumerator MoveObject(Vector3 target, float overTime)
    {
        float startTime = Time.time;

        Quaternion targetRot = Quaternion.Euler(target);
        Quaternion _newRot;
        while (transform.localRotation.eulerAngles.y < target.z - 1)
        {
            _newRot = Quaternion.Slerp(transform.rotation, targetRot, speed);
            gameObject.transform.rotation = _newRot;
            yield return new WaitForFixedUpdate();
        }
        
        if(newRot.z < 360)
        {
            newRot.z += value;
        }
        else
        {
            newRot.z = value;
            rot.Set(0, 0, 0);
            targetRot.Set(resetTargetRotation.x, resetTargetRotation.y, resetTargetRotation.z, resetTargetRotation.w);//Needs to be equal to new rot starting values
            transform.eulerAngles = new Vector3(resetLocalRotation.x, resetLocalRotation.y, resetLocalRotation.z);//Needs to be equal to objects local transform rotation values

            while (transform.localRotation.eulerAngles.y >= target.z)
            {
                _newRot = Quaternion.Slerp(transform.rotation, targetRot, speed);
                gameObject.transform.rotation = targetRot;
                Debug.Log("newRot" + _newRot);
                yield return new WaitForFixedUpdate();
            }
        }
    }

    IEnumerator MoveObject_02(Vector3 target, float overTime)
    {
        float startTime = Time.time;
        Quaternion targetRot = Quaternion.Euler(target);
        Quaternion _newRot;
        while (transform.localRotation.eulerAngles.y < target.y - 1)
        {
            _newRot = Quaternion.Slerp(transform.rotation, targetRot, speed);
            gameObject.transform.rotation = _newRot;
            yield return new WaitForFixedUpdate();
        }
        newRot.y += value;
    }
    #endregion

    #region Functions

    private void Start()
    {
        toolManager = FindObjectOfType<ToolsManager>();
        correctRotation = Random.Range(min, max); 
    }

    public void Lerp() //Coffin
    {
        if(hasFinishedLooped == true)
        {
            StartCoroutine(LerpDelay());

            if (timesRotated <= 6)
            {
                timesRotated += 1;
            }

            else
            {
                timesRotated = 0;
            }
        }
    }
    IEnumerator LerpDelay()
    {
        hasFinishedLooped = false;
        yield return new WaitForSeconds(.75f);
        rot = gameObject.transform.eulerAngles;
        StartCoroutine(MoveObject(newRot, (Time.time - 0) / 5));
        PlayAudio();
        yield return new WaitForSeconds(.75f);
        hasFinishedLooped = true;
    }

    public void Lerp_02() //Doors
    {       
        
        if (toolManager.keysCollected == doorReq)
        {
            if (rotated == false)
            {
                rot = gameObject.transform.eulerAngles;
                StartCoroutine(MoveObject_02(newRot, (Time.time - 0) / 5));
                rotated = true;
                triggerObj.SetActive(false);
                inputSprite.SetActive(false);
                source.Play();
            }
        }
       
        
    }   

    public void PlayAudio()
    {
        source.Play();
    }

    public void Rotate()
    {
        float angle = Mathf.LerpAngle(minAngle, maxAngle, speed);
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, angle);
    }
	#endregion
}
