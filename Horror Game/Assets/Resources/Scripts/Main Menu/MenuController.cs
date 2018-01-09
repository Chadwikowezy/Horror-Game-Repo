using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image fadeScreenImage;
    public GameObject optionsMenu;
    public GameObject creditsMenu;

    [Header("Flickering Light")]
    public Light flickeringLight;
    public int minNumOfFlickers;
    public int maxNumOfFlickers;
    public float minWaitTime;
    public float maxWaitTime;

    [Header("Animators")]
    public Animator menuOptionsAnim;

    private void Start()
    {
        StartCoroutine(flickerLight());
    }

    IEnumerator flickerLight()
    {
        int numOfFlickers;

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));

            numOfFlickers = Random.Range(minNumOfFlickers, maxNumOfFlickers);

            for (int i = 0; i < numOfFlickers; i++)
            {
                yield return new WaitForSeconds(Random.Range(0.05f, 0.2f));

                flickeringLight.enabled = !flickeringLight.enabled;
            }
        }
    }
    IEnumerator fadeScreen()
    {
        fadeScreenImage.gameObject.SetActive(true);

        while (fadeScreenImage.color != Color.black)
        {
            yield return new WaitForFixedUpdate();

            fadeScreenImage.color = Color.Lerp(fadeScreenImage.color, Color.black, 0.05f);
        }
    }

    //Button Functions
    public void newGameButton()
    {
        menuOptionsAnim.SetBool("Loading Game", true);

        StartCoroutine(fadeScreen());
    }
    public void loadGameButton()
    {
        menuOptionsAnim.SetBool("Loading Game", true);

        StartCoroutine(fadeScreen());
    }
    public void optionsButton()
    {
        optionsMenu.SetActive(!optionsMenu.active);
    }
    public void creditsButton()
    {
        creditsMenu.SetActive(!creditsMenu.active);
    }
    public void quitButton()
    {
        Application.Quit();
    }
}
