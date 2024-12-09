using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public sealed class World //used for queues in resolving conflicts later
{
    // singleton as we only want one instance at a time
    private static readonly World instance = new World();
    private static WorldStates world;

    // new code for dynamic GameObject tracking
    private static Queue<GameObject> patients;
    private static Queue<GameObject> cubicles;

    static World ()
    {
        world = new WorldStates();
        patients = new Queue<GameObject>();
        cubicles = new Queue<GameObject>();
        GameObject[] cubs = GameObject.FindGameObjectsWithTag("Cubicle");
        foreach (GameObject c in cubs)
        {
            cubicles.Enqueue(c);
        }
        if (cubs.Length > 0)
        {
            world.ModifyState("freeCubicle", cubs.Length); // can be a precondition as a world resource
        }
    }

    private World()
    {

    }

    public void AddCubicle(GameObject p)
    {
        cubicles.Enqueue(p);
    }

    public GameObject RemoveCubicle()
    {
        if (cubicles.Count == 0) return null;
        return cubicles.Dequeue();
    }

    public void AddPatient(GameObject p)
    {
        patients.Enqueue(p);
    }

    public GameObject RemovePatient()
    {
        if (patients.Count == 0) return null;
        return patients.Dequeue();
    }

    public static World Instance
    {
        get { return instance; }
    }
    public WorldStates GetWorld()
    {
        return world;
    }
}
