using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndOfGameCanvas : MonoBehaviour
{
    public GameObject player;
    public GameObject endOfGameTrigger;

    public RectTransform credits;

    public float detectionDistance;
    public float fadeSpeed;
    public float scrollSpeed;
    public float maxscrollSpeed;

    public Image fadeOutScreen;

    private bool gameEnding;
    private float creditsYChange;
    private Vector3 newScrollPos;

    public AudioSource audioSource_01, audioSource_02, audioSource_03;

    private void Update()
    {
        if (gameEnding == false)
        {
            fadeOutScreen.color = Color.Lerp(fadeOutScreen.color, Color.clear, fadeSpeed * Time.deltaTime);

            if ((player.transform.position - endOfGameTrigger.transform.position).magnitude < detectionDistance)
            {
                gameEnding = true;
                StartCoroutine("AudioDelay");
            }
               
        }
        else
        {
            fadeOutScreen.color = Color.Lerp(fadeOutScreen.color, Color.black, fadeSpeed * Time.deltaTime);

            if (fadeOutScreen.color.a > 0.75f && credits.transform.localPosition.y < 0)
            {
                creditsYChange = scrollSpeed * Time.deltaTime * (Vector3.zero - credits.transform.localPosition).magnitude;
                creditsYChange = Mathf.Clamp(creditsYChange, 0, maxscrollSpeed);
                newScrollPos = credits.transform.localPosition;
                newScrollPos.y += creditsYChange;
                credits.transform.localPosition = newScrollPos;
            }
        }
    }

    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(3f);
        audioSource_01.Stop();
        audioSource_02.Stop();
        audioSource_03.Play();
    }
}
