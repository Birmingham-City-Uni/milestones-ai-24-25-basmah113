﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControl : MonoBehaviour {

	GameObject[] goalLocations;
	NavMeshAgent agent;

	Animator anim;

	// Use this for initialization
	void Start () {
		goalLocations = GameObject.FindGameObjectsWithTag("goal");
		agent = this.GetComponent<NavMeshAgent>();
		agent.SetDestination(goalLocations[Random.Range(0,goalLocations.Length)].transform.position);

		anim = this.GetComponent<Animator>();
		anim.SetTrigger("iswalking");
		anim.SetFloat("walkOffset", Random.Range(0,1));
		float sm = Random.Range(0.8f,1.2f);
		anim.SetFloat("speedMult", sm);
		agent.speed *= sm;
	}
	
	// Update is called once per frame
	void Update () {
		if(agent.remainingDistance < 1)
		{
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }
}
