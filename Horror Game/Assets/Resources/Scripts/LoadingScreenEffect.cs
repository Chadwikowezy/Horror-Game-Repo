using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenEffect : MonoBehaviour
{	
	void LateUpdate ()
    {
        transform.Rotate(Vector3.back * Time.deltaTime * 40f);
	}
}
