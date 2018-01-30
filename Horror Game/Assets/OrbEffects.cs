using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbEffects : MonoBehaviour
{
    public List<GameObject> orbs = new List<GameObject>();
    public float rotationSpeed;

    private Spector spector;

	void Start ()
    {
        spector = FindObjectOfType<Spector>();
	}


    void LateUpdate ()
    {
        Vector3 spectorPos = new Vector3(spector.transform.position.x, spector.transform.position.y + 1, spector.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, spectorPos, 1);

        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
	}
}
