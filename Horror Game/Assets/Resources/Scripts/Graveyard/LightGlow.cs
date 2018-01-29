using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]

public class LightGlow : MonoBehaviour
{
    public float startIntensity;
    public float amplitude;
    public float period;

    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
        _light.intensity = startIntensity;
    }
    private void Update()
    {
        
    }
}
