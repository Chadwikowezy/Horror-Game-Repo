using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject triggerPrefab;

    [Range(0,1)]
    public float speed;

    public float minAngle = 0.0F;
    public float maxAngle = 90.0F;
    public float value;

    public Vector3 rot,
                newRot;
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

        newRot.z += value;
       //fix 
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
    public void Lerp()
    {
        rot = gameObject.transform.eulerAngles;
        StartCoroutine(MoveObject(newRot, (Time.time - 0) / 5));
    }

    public void Lerp_02()
    {
        rot = gameObject.transform.eulerAngles;
        StartCoroutine(MoveObject_02(newRot, (Time.time - 0) / 5));
    }

    public void PlayAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void Rotate()
    {
        float angle = Mathf.LerpAngle(minAngle, maxAngle, speed);
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, angle);
    }
	#endregion
}
