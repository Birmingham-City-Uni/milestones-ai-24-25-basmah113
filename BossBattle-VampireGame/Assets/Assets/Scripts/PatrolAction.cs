using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;

[Action("Custom/PatrolAction")]
public class PatrolAction : BasePrimitiveAction
{
	[InParam("navMeshAgent")]
	public NavMeshAgent navMeshAgent;

	[InParam("waypoints")]
	public Transform[] waypoints;

	private int currentWaypoint = 0;

	public override void OnStart()
	{
		// Validation in OnStart
		if (navMeshAgent == null || waypoints == null || waypoints.Length == 0)
		{
			Debug.LogError("PatrolAction is missing critical components!");
			return;
		}

		Debug.Log($"PatrolAction: Waypoints count = {waypoints.Length}");
		navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
	}

	public override TaskStatus OnUpdate()
	{
		// Validation in OnUpdate
		if (navMeshAgent == null || waypoints == null || waypoints.Length == 0)
		{
			Debug.LogError("PatrolAction is missing critical components!");
			return TaskStatus.FAILED;
		}

		// Check if the agent has reached the current waypoint
		if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
		{
			// Move to the next waypoint
			currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
			navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
		}

		// Return running to indicate ongoing patrol
		return TaskStatus.RUNNING;
	}
}
