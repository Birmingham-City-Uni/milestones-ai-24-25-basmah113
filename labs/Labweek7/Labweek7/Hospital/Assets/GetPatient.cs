using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPatient : Action
{
    GameObject resource; 

    public override bool PrePerform()
    {
        // precondition check if a patient is waiting
        // now get the patient that this instance of nurse will be treating
        target = World.Instance.RemovePatient();
        if (target == null)
        {
           return false;
        }
        resource = World.Instance.RemoveCubicle();
        if (resource != null) inventory.AddItem(resource);
        else
        {
            World.Instance.AddPatient(target);
            target = null;
            return false;
        }
        World.Instance.GetWorld().ModifyState("freeCubicle", -1); 
        return true;
    }
    public override bool PostPerform()
    {
        World.Instance.GetWorld().ModifyState("patientWaiting", -1);
        if (target)
            target.GetComponent<Agent>().inventory.AddItem(resource);
        return true;
    }
}
