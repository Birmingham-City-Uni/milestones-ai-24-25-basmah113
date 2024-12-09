using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWaitingRoom : Action
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        World.Instance.GetWorld().ModifyState("patientWaiting", 1);
        // Add Patient into world queue
        World.Instance.AddPatient(this.gameObject);
        return true;
    }
}
