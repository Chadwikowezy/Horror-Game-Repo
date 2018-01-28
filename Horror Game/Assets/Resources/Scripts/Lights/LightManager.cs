using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public List<Light> lights = new List<Light>();
    private Spector spector;

    private float timeOn = .1f;
    private float timeOff = .5f;
    private float changeTime = 0;

	void Start ()
    {
        spector = FindObjectOfType<Spector>();
	}
	
	void LateUpdate ()
    {
        FlashOnSpectorDistance();
    }

    void FlashOnSpectorDistance()
    {
        foreach(Light light in lights)
        {
            if(Vector3.Distance(light.transform.position, spector.transform.position) <= 10f)
            {
                if(Time.time > changeTime)
                {
                    light.enabled = !light.enabled;
                    if(light.enabled)
                    {
                        changeTime = Time.time + timeOn;
                    }
                    else
                    {
                        changeTime = Time.time + timeOff;
                    }
                }
            }
            else
            {
                light.enabled = true;
            }
        }
    }
}
