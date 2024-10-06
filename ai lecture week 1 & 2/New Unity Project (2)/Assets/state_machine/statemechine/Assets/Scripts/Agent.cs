using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    statemanager sm = new statemanager();

    bool state_change = false;
    void Start()
    {
        sm.ChangeState(new IdleState(this));
    }

  
    void Update()
    {
        sm.Update();
        if(this.transform.position.x > 5.0f && !state_change)
        {
            sm.ChangeState(new FleeState(this));
            state_change = !state_change;
        }
        if (this.transform.position.x < 5.0f && !state_change)
        {
            sm.ChangeState(new IdleState(this));
            state_change = !state_change;
        }
    }
}
