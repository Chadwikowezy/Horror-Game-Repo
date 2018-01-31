using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public List<Light> lights = new List<Light>();
    private Spector spector;

    public List<GameObject> lightObjects = new List<GameObject>();

    private PlayerMotor player;

    private float timeOn = .1f;
    private float timeOff = .5f;
    private float changeTime = 0;

	void Start ()
    {
        spector = FindObjectOfType<Spector>();
        player = FindObjectOfType<PlayerMotor>();
    }
	
	void LateUpdate ()
    {
        for (int i = 0; i < lightObjects.Count; i++)
        {
            if(Vector3.Distance(lightObjects[i].transform.position, player.transform.position) < 30f)
            {
                lightObjects[i].SetActive(true);
                FlashOnSpectorDistance();
            }
            else
            {
                lightObjects[i].SetActive(false);
            }
        }
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
