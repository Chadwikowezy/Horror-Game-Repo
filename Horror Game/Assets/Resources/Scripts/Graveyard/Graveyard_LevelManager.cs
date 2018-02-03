using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graveyard_LevelManager : MonoBehaviour
{
    public GameObject player;

    [Space(10), Header("Start Light Fade In")]
    public Light[] startingLights;
    public float fadeDuration;

    [Space(10), Header("Collected Objects")]
    public Image knifeImage;
    public Image compassImage;
    public Sprite knifeSprite;
    public Sprite compassSprite;
    private bool _hasKnife;
    private bool _hasCompass;

    public bool HasKnife
    {
        get { return _hasKnife; }
        set
        {
            _hasKnife = value;

            if (_hasKnife == true)
                knifeImage.sprite = knifeSprite;
        }
    }
    public bool HasCompass
    {
        get { return _hasCompass; }
        set
        {
            _hasCompass = value;

            if (_hasCompass == true)
                compassImage.sprite = compassSprite;
        }
    }

    private void Start()
    {
        player.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
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

        for (int i = 0; i < startingLights.Length; i++)
        {
            startingLights[i].gameObject.GetComponent<LightGlow>().enabled = true;
            yield return new WaitForSeconds(1f);
        }
    }
}
