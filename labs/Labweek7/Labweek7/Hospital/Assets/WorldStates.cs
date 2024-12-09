using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[System.Serializable]

public class WorldState
{
    public string key; //dictionary for representing states
    public int value; // e.g. freecubicles key and value 5
}

public class WorldStates
{
    public Dictionary<string, int> states;
    public WorldStates()
    {
        states = new Dictionary<string, int>();
    }

    public bool HasState(string key)
    {
        return states.ContainsKey(key);
    }
    void AddState(string key, int value)
    {
        states.Add(key, value);
    }
    public void ModifyState(string key, int value) 
    {
        if (states.ContainsKey(key))
        {
            states[key] += value;
            if (states[key] <= 0) RemoveState(key); // remove key if negative - used to modify numcubciles
        }
        else states.Add(key, value);
    }
    public void RemoveState(string key)
    {
        if (states.ContainsKey(key)) states.Remove(key);
    }
    public void SetState(string key, int value)
    {
        if (states.ContainsKey(key)) states[key] = value;
        else states.Add(key, value);
    }
    public Dictionary<string, int> GetStates()
    {
        return states;
    }
}
