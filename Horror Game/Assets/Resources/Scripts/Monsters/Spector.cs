using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spector : MonoBehaviour
{
    //Variables
    private MonsterStates _currentState;

    //Properties
    public MonsterStates CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }

    //Functions

    void wander()
    { }
}
