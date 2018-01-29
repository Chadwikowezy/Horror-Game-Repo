using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]

public class LightGlow : MonoBehaviour
{
    public bool useDefaultValuesInstead = true;

    public float startIntensity;
    public float maxIntensity;
    public float intensityChange;

    private bool _addingIntensity;
    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
        _light.intensity = startIntensity;
        _addingIntensity = true;

        if (useDefaultValuesInstead)
        {
            startIntensity = _light.intensity;
            maxIntensity = startIntensity + 1;
            intensityChange = 0.01f;
        }
    }
    private void FixedUpdate()
    {
        if (_light.intensity < startIntensity || _light.intensity > maxIntensity)
            _addingIntensity = !_addingIntensity;

        if (_addingIntensity)
            _light.intensity += intensityChange;
        else
            _light.intensity -= intensityChange;
    }
}
