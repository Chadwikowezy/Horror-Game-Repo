using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Graveyard_LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject spector;

    [Space(10), Header("Start Light Fade In")]
    public Light[] startingLights;
    public float fadeDuration;
    public Canvas graveyardCanvas;
    public Image fadeOutScreen;
    public float fadeSpeed;

    [Space(10), Header("Collected Objects")]
    public Image knifeImage;
    public Image compassImage;
    public Sprite knifeSprite;
    public Sprite compassSprite;
    public Button collectKnifeButton;
    public Button collectCompassButton;
    public Button placeFoundItemsButton;
    public GameObject knife;
    public GameObject placedKnife;
    public GameObject compass;
    public GameObject placedCompass;
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
        StartCoroutine(fadeIntoScene());
    }

    public void pickupKnifeButton()
    {
        HasKnife = true;
        collectKnifeButton.gameObject.SetActive(false);
        Destroy(knife);
    }
    public void pickupCompassButton()
    {
        HasCompass = true;
        collectCompassButton.gameObject.SetActive(false);
        Destroy(compass);
    }
    public void placeItemsButton()
    {
        if (HasKnife)
            placedKnife.SetActive(true);

        if (HasCompass)
            placedCompass.SetActive(true);

        if (HasKnife && HasCompass)
        {
            placeFoundItemsButton.gameObject.SetActive(false);
            player.GetComponent<PlayerMotor>().enabled = false;
            spector.SetActive(false);
            StartCoroutine(loadEndOfGameAnimation());
        }
    }

    IEnumerator loadEndOfGameAnimation()
    {
        yield return new WaitForSeconds(1f);

        graveyardCanvas.sortingOrder = 2;
        fadeOutScreen.gameObject.SetActive(true);

        while (fadeOutScreen.color.a < 0.99f)
        {
            fadeOutScreen.color = Color.Lerp(fadeOutScreen.color, Color.black, fadeSpeed);

            yield return new WaitForFixedUpdate();
        }

        SceneManager.LoadScene("End Of Game Cutscene");
    }
    IEnumerator fadeIntoScene()
    {
        fadeOutScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        graveyardCanvas.sortingOrder = 2;

        while (fadeOutScreen.color.a > 0.1f)
        {
            fadeOutScreen.color = Color.Lerp(fadeOutScreen.color, Color.clear, fadeSpeed);

            yield return new WaitForFixedUpdate();
        }

        graveyardCanvas.sortingOrder = 0;

        fadeOutScreen.gameObject.SetActive(false);
    }
}
