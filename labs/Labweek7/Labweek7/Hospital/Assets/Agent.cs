using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting; //for sorting

public class SubGoal //helper class for agent 
{
    public Dictionary<string, int> sgoals; // nurse resting (don't need to remove)
    public bool remove; //some agents need to be given a goal, when satisfied remove from their intentions
    public SubGoal(string s, int i, bool r)
    {
        sgoals = new Dictionary<string, int>();
        sgoals.Add(s, i);
        remove = r;
    }
}

public class Agent : MonoBehaviour
{
    public List<Action> actions = new List<Action>(); // list of actions to perform
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();
    public Inventory inventory = new Inventory();
    Planner planner; //returns a queue of actions
    Queue<Action> actionQueue;
    public Action currentAction;
    SubGoal currentGoal;

    // Start is called before the first frame update
    public void Start()
    {
        Action[] acts = this.GetComponents<Action>(); //can drag actions onto the agent
        foreach (Action a in acts)
            actions.Add(a);
    }
    bool invoked = false;
    void CompleteActions()
    {
        currentAction.running = false;
        currentAction.PostPerform();
        invoked = false;
    }
    //LateUpdate is called once per frame
    void LateUpdate()
    {
        // IsAchievable  may need to be influenced by other logic - we assume these are all possible
        // need to implement planner here
        // gets goals that need to be satisfied
        // gets a list of actions available to us
        // gets world states
        // builds a tree of actions
        // search graph to develop a plan to give a series of action to give us the goal
        if(currentAction !=null && currentAction.running)
        {
            if(currentAction.agent.hasPath && currentAction.agent.remainingDistance < 1f) //navmesh code
            {
                if(!invoked)
                {
                    Invoke("CompleteAction", currentAction.duration);
                    invoked = true;
                }
            }
            return;
        }
        if(planner == null || actionQueue ==null)
        {
            planner = new Planner();
            var sortedGoals = from entry in goals orderby entry.Value descending select entry;
            foreach (KeyValuePair<SubGoal, int> sg in sortedGoals)
            {
                actionQueue = planner.plan(actions, sg.Key.sgoals, null);
                if(actionQueue != null)
                {
                    currentGoal = sg.Key;
                    break;
                }
            }
        }
        //have we done all actions? 
        if(actionQueue != null && actionQueue.Count == 0)
        {
            if(currentGoal.remove) //if goal working on is removeable
            {
                goals.Remove(currentGoal);
            }
            planner = null;
        }

        if (actionQueue != null && actionQueue.Count > 0) //if action queue and we still have actions to do
        {
            currentAction = actionQueue.Dequeue();
            if(currentAction.PrePerform()) //check cublicles available etc
            {
                if(currentAction.target == null && currentAction.targetTag != "")
                {
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);
                }
                if(currentAction.target != null)
                {
                    currentAction.running = true; // action starts to take place
                    currentAction.agent.SetDestination(currentAction.target.transform.position);
                }
            }
            else //if preperform fails
            {
                actionQueue = null;
            }
        }
    }
}
