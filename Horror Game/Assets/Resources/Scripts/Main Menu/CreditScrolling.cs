using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScrolling : MonoBehaviour
{
    public float scrollSpeed;
    public float maxscrollSpeed;

    public Vector3 startPosition;

    private float creditsYChange;
    private Vector3 newScrollPos;

    private void Update()
    {
        scrollCredits();
    }

    void scrollCredits()
    {
        creditsYChange = scrollSpeed * Time.deltaTime * (Vector3.zero - transform.localPosition).magnitude;
        creditsYChange = Mathf.Clamp(creditsYChange, 0, maxscrollSpeed);
        newScrollPos = transform.localPosition;
        newScrollPos.y += creditsYChange;
        transform.localPosition = newScrollPos;
    }
    private void OnEnable()
    {
        transform.localPosition = startPosition;
    }

    public void exitCreditsButton()
    {
        gameObject.SetActive(false);
    }
}
