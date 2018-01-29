using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard_LevelManager : MonoBehaviour
{
    [Space(10), Header("Start Light Fade In")]
    public Light[] startingLights;
    public float fadeDuration;

    private void Start()
    {
        StartCoroutine(lightFadeIn());
    }

    IEnumerator lightFadeIn()
    {
        float _currentTime = 0;
        float _lerpAmount = 0;
        Color _currentLightColor = startingLights[0].color;

        while (_currentLightColor != Color.white)
        {
            yield return new WaitForFixedUpdate();

            _currentTime += Time.fixedDeltaTime;
            if (_currentTime > fadeDuration)
                _currentTime = fadeDuration;
            _lerpAmount = _currentTime / fadeDuration;
            _currentLightColor = Color.Lerp(_currentLightColor, Color.white, _lerpAmount);

            for (int i = 0; i < startingLights.Length; i++)
                startingLights[i].color = _currentLightColor;
        }
    }
}
