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
    private float _fadeTarget;
    private float _theta;
    private float _distance;

    private void Start()
    {
        _light = GetComponent<Light>();
        _light.intensity = startIntensity;
    }
    private void Update()
    {
        _theta = Time.timeSinceLevelLoad / period;
        _distance = amplitude * Mathf.Sin(_theta);

        _light.intensity = startIntensity +  _distance;
    }
}
