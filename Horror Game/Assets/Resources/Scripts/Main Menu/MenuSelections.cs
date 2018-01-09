using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelections : MonoBehaviour
{
    public bool newGame;
    public int difficultyLevel;
    public float volumeLevel;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}