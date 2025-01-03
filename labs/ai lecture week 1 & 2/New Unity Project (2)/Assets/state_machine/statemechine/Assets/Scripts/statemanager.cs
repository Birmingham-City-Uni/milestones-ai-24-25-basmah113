using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statemanager 
{
    State currState;
    public void ChangeState(State newState)
    {
        if (currState != null)
        {
            currState.Exit();
        }
       
        currState = newState;
        newState.Enter();
    }
    public void Update()
    {
        if(currState != null) currState.Execute();
    }
}
