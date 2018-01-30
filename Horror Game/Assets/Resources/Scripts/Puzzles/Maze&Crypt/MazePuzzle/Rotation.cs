using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private GameObject triggerPrefab;

    [Range(0,1)]
    public float speed;

    public float minAngle = 0.0F;
    public float maxAngle = 45.0F;

    public void Rotate()
    {
        float angle = Mathf.LerpAngle(minAngle, maxAngle, speed);
        transform.eulerAngles = new Vector3(0, 0, angle);
        //triggerPrefab.transform.rotation = Quaternion.Slerp(triggerPrefab.transform.rotation, Quaternion.Euler(0, 0, 45), speed );
        print("rotated");
    }
	
}
