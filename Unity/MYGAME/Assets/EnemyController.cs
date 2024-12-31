using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	public enum AISTATE { PATROL, CHASE, ATTACK };

	public Transform player;
	public NavMeshAgent enemy;
	public AISTATE enemyState = AISTATE.PATROL;
	public float distanceOffset = 2f;

	public List<Transform> waypoints = new List<Transform>();
	private Transform currentWaypoint;

	private void Start()
	{
		if (waypoints.Count > 0)
		{
			currentWaypoint = waypoints[Random.Range(0, waypoints.Count)];
			ChangeState(AISTATE.PATROL);
		}
		else
		{
			Debug.LogError("No waypoints assigned for patrol!");
		}
	}

	public void ChangeState(AISTATE newState)
	{
		Debug.Log($"Changing state to {newState}");
		StopAllCoroutines();
		enemyState = newState;

		switch (enemyState)
		{
			case AISTATE.PATROL:
				StartCoroutine(PatrolState());
				break;
			case AISTATE.CHASE:
				StartCoroutine(ChaseState());
				break;
			case AISTATE.ATTACK:
				StartCoroutine(AttackState());
				break;
		}
	}

	public IEnumerator PatrolState()
	{
		Debug.Log("Enemy in PATROL state.");
		while (enemyState == AISTATE.PATROL)
		{
			enemy.SetDestination(currentWaypoint.position);
			if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceOffset)
			{
				currentWaypoint = waypoints[Random.Range(0, waypoints.Count)];
			}
			yield return null;
		}
	}

	public IEnumerator ChaseState()
	{
		Debug.Log("Enemy in CHASE state.");
		while (enemyState == AISTATE.CHASE)
		{
			if (Vector3.Distance(transform.position, player.position) < distanceOffset)
			{
				ChangeState(AISTATE.ATTACK);
				transform.LookAt(player.position);
				yield break;
			}

			enemy.SetDestination(player.position);
		
			yield return null;
		}
	}

	public IEnumerator AttackState()
	{
		Debug.Log("Enemy in ATTACK state.");
		while (enemyState == AISTATE.ATTACK)
		{
			if (Vector3.Distance(transform.position, player.position) > distanceOffset)
			{
				ChangeState(AISTATE.CHASE);
				yield break;
			}

			Debug.Log("Attack!");
			player.GetComponent<HealthManager>().TakeDamage(10f);
			yield return new WaitForSeconds(1f); 
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log($"OnTriggerEnter triggered by: {other.gameObject.name}");

		if (other.CompareTag("Player"))
		{
			Debug.Log("Player detected. Changing state to CHASE.");
			ChangeState(AISTATE.CHASE);
		}
	}

}
