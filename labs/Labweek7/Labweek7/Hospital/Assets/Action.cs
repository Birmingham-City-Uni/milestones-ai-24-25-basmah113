using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Action : MonoBehaviour // pertains to the details of the actions
{
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target; //location where action will happen
    public string targetTag; // pickup gameobject using tag - if exist in hierarchy
    public float duration = 0; //how long will this action take?
    public WorldState[] preConditions; // get via inspector (serializable) - put into dictionaries
    public WorldState[] afterEffects;
    public NavMeshAgent agent; //attached to agent for movement
    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;
    public WorldStates agentBeliefs;
    public bool running = false; //default false, need to know if we're running the Action

    public Inventory inventory;

    public Action()
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }

    public void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        if(preConditions != null)
        {
            foreach(WorldState w in preConditions)
            {
                preconditions.Add(w.key, w.value);
            }
        }
        if (afterEffects != null)
        {
            foreach (WorldState w in afterEffects)
            {
                effects.Add(w.key, w.value);
            }
        }

        inventory = this.GetComponent<Agent>().inventory;
    }

    public bool IsAchievable()
    {
        return true; //change later - assume true for now
    }

    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach(KeyValuePair<string, int> p in preconditions)
        {
            if (!conditions.ContainsKey(p.Key)) return false;
        }
        return true; //preconditions exist so it is possible
    }

    public abstract bool PrePerform(); // allow custom code to ensure things can be done before
    public abstract bool PostPerform(); // and after the action 
}
