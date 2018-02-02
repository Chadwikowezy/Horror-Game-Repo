using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour
{
    public GameObject matchPrefab;
    public GameObject targetParentObject;

    public int currentMatchCount;

    public float noMatchesFadeSpeed;

    public Image noMatchesImage;

    private GameObject _currentMatch;

    private void FixedUpdate()
    {
        if (noMatchesImage.color != Color.clear)
            noMatchesImage.color = Color.Lerp(noMatchesImage.color, Color.clear, noMatchesFadeSpeed);
    }

    public void strikeMatch()
    {
        if (_currentMatch != null)
            return;

        if (currentMatchCount > 0)
        {
            currentMatchCount--;
            _currentMatch = Instantiate(matchPrefab, targetParentObject.transform);
        }
        else
        {
            noMatchesImage.color = Color.white;
        }
    }
    public void strikeMatch(Transform targetPosition)
    {
        if (_currentMatch != null)
            return;

        if (currentMatchCount > 0)
        {
            currentMatchCount--;
            _currentMatch = Instantiate(matchPrefab, targetPosition.position, Quaternion.identity);

            _currentMatch.GetComponent<Match>().strikeMatch(targetPosition);
        }
        else
        {
            noMatchesImage.color = Color.white;
        }
    }
}
