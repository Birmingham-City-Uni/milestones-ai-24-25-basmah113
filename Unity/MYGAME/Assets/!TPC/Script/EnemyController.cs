using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	private Vector3 lastNoisePosition;
	private bool noiseDetected = false;

	public Transform[] retreatPoints;
	public Transform[] powerUps;

	public enum AISTATE { PATROL, CHASE, ATTACK };

	public Transform player;
	public NavMeshAgent enemy;
	public AISTATE enemyState = AISTATE.PATROL;
	public float distanceOffset = 2f;
	public float detectionRange, AttackRange;
	public Animator _anim;
	public List<Transform> waypoints = new List<Transform>();
	private Transform currentWaypoint;
	public bool isAttack, isDie;

	private float noiseCooldown = 2f; 
	private float lastNoiseTime = 0f;

	private BFSPathfinding bfs;
	private DFSPathfinding dfs;


	void Start()
	{
		isAttack = false;
		bfs = new BFSPathfinding();
		dfs = new DFSPathfinding();


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

	void Update()
	{
		if (!isDie)
		{
			CheckPlayerInRange();

			if (enemyState == AISTATE.PATROL)
			{
				PatrolUsingDFS();
			}
			else if (enemyState == AISTATE.CHASE)
			{
				ChaseUsingBFS();
			}

			if (noiseDetected && Time.time > lastNoiseTime + noiseCooldown)
			{
				HeardNoise(lastNoisePosition);
				noiseDetected = false; 
				lastNoiseTime = Time.time;
			}
		}
	}

	void PatrolUsingDFS()
	{
		List<Transform> path = dfs.ExploreDeep(transform, null, waypoints.ToArray());
		if (path.Count > 0)
		{
			Transform nextWaypoint = path[0]; 
			enemy.SetDestination(nextWaypoint.position);
		}
		else
		{
			Debug.LogWarning("DFS could not find a valid path for patrol!");
		}
	}

	void ChaseUsingBFS()
	{
		List<Transform> path = bfs.FindShortestPath(transform, player, waypoints.ToArray());
		if (path.Count > 0)
		{
			Transform nextPoint = path[0]; 
			enemy.SetDestination(nextPoint.position);
		}
		else
		{
			Debug.LogWarning("BFS could not find a valid path to the player!");
		}
	}


	public void NotifyNoise(Vector3 noisePosition)
	{
		lastNoisePosition = noisePosition;
		noiseDetected = true;
	}

	public void ChangeState(AISTATE newState)
	{
		StopAllCoroutines();
		enemyState = newState;

		switch (enemyState)
		{
			case AISTATE.PATROL:
				StartCoroutine(PatrolState());
				_anim.SetFloat("Speed", 0.1f);
				break;
			case AISTATE.CHASE:
				StartCoroutine(ChaseState());
				_anim.SetFloat("Speed", 0.2f);
				break;
			case AISTATE.ATTACK:
				StartCoroutine(AttackState());
				break;
		}
	}

	public IEnumerator PatrolState()
	{
		while (enemyState == AISTATE.PATROL)
		{
			if (currentWaypoint != null)
			{
				enemy.SetDestination(currentWaypoint.position);

				if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceOffset)
				{
					currentWaypoint = waypoints[Random.Range(0, waypoints.Count)];
				}
			}
			yield return null;
		}
	}

	public IEnumerator ChaseState()
	{
		while (enemyState == AISTATE.CHASE)
		{
			if (Vector3.Distance(transform.position, player.position) < AttackRange)
			{
				isAttack = true;
				ChangeState(AISTATE.ATTACK);
				yield break;
			}

			enemy.isStopped = false;
			enemy.SetDestination(player.position);

			yield return null;
		}
	}

	public IEnumerator AttackState()
	{
		while (enemyState == AISTATE.ATTACK)
		{
			if (Vector3.Distance(transform.position, player.position) > AttackRange)
			{
				isAttack = false;
				ChangeState(AISTATE.CHASE);
				yield break;
			}

			_anim.SetFloat("Speed", 0.4f);
			enemy.isStopped = true;

			HealthManager playerHealth = player.GetComponent<HealthManager>();
			if (playerHealth != null)
			{
				playerHealth.TakeDamage(10f);
			}

			yield return new WaitForSeconds(1f);
		}
	}

	void ChasePlayerWithBFS()
	{
		List<Transform> path = bfs.FindShortestPath(transform, player, retreatPoints);

		if (path != null && path.Count > 0)
		{
			enemy.SetDestination(path[0].position); 
		}
		else
		{
			Debug.LogWarning("No path found to player.");
		}
	}

	public void HeardNoise(Vector3 noisePosition)
	{
		if (!isDie && enemyState != AISTATE.ATTACK)
		{
			float distanceToNoise = Vector3.Distance(transform.position, noisePosition);
			Debug.Log($"Enemy {name} heard noise at {noisePosition}. Distance to noise: {distanceToNoise}");

			if (distanceToNoise <= detectionRange)
			{
				Debug.Log($"Enemy {name} is responding to noise. Switching to CHASE.");
				ChangeState(AISTATE.CHASE);
				enemy.SetDestination(noisePosition);
			}
			else
			{
				Debug.Log($"Enemy {name} ignored noise. Out of detection range.");
			}
		}
	}



	void CheckPlayerInRange()
	{
		if (!isDie)
		{
			float distance = Vector3.Distance(this.transform.position, player.position);

			if (distance <= detectionRange && enemyState == AISTATE.PATROL)
			{
				ChangeState(AISTATE.CHASE);
				Debug.Log("Player detected via proximity! Switching to CHASE.");
			}
			else if (distance > detectionRange && enemyState != AISTATE.PATROL)
			{
				ChangeState(AISTATE.PATROL);
				Debug.Log("Player out of range. Returning to PATROL.");
			}
		}
	}

	public void GetHit(float damage)
	{
		if (!isDie)
		{
			// Reduce enemy health
			HealthManager healthManager = GetComponent<HealthManager>();
			if (healthManager != null)
			{
				healthManager.TakeDamage(damage);
			}

			// Check if health reaches 0
			if (healthManager != null && healthManager.GetHealth() <= 0)
			{
				isDie = true;
				_anim.SetTrigger("Die");
				Debug.Log($"{name} has died.");
			}
			else
			{
				_anim.SetTrigger("TakeHit"); 
			}
		}
	}

}
