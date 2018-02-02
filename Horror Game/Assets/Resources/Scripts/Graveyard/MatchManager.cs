﻿using System.Collections;
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
    public Text matchCountText;

    private GameObject _currentMatch;

    public int CurrentMatchCount
    {
        get { return currentMatchCount; }
        set
        {
            currentMatchCount = value;
            matchCountText.text = currentMatchCount.ToString();
        }
    }

    private void FixedUpdate()
    {
        if (noMatchesImage.color != Color.clear)
            noMatchesImage.color = Color.Lerp(noMatchesImage.color, Color.clear, noMatchesFadeSpeed);
    }

    public void strikeMatch()
    {
        if (_currentMatch != null)
            return;

        if (CurrentMatchCount > 0)
        {
            CurrentMatchCount--;
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

        if (CurrentMatchCount > 0)
        {
            CurrentMatchCount--;
            _currentMatch = Instantiate(matchPrefab, targetPosition.position, Quaternion.identity);

            _currentMatch.GetComponent<Match>().strikeMatch(targetPosition);
        }
        else
        {
            noMatchesImage.color = Color.white;
        }
    }
    public void strikePlayerMatch(Transform holdPosition)
    {
        Vector3 spawnPosition = holdPosition.position - new Vector3(-1, 1, 0);

        if (_currentMatch != null)
            return;

        if (CurrentMatchCount > 0)
        {
            CurrentMatchCount--;
            _currentMatch = Instantiate(matchPrefab, spawnPosition, Quaternion.identity);

            _currentMatch.GetComponent<Match>().strikeMatch(holdPosition);
        }
        else
        {
            noMatchesImage.color = Color.white;
        }
    }
}
