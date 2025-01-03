using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;

[Action("Custom/RetreatAction")]
public class RetreatAction : BasePrimitiveAction
{
	[InParam("navMeshAgent")]
	public NavMeshAgent navMeshAgent;

	[InParam("retreatPoint")]
	public Transform retreatPoint;

	public override void OnStart()
	{
		if (retreatPoint != null)
		{
			navMeshAgent.SetDestination(retreatPoint.position);
		}
	}

	public override TaskStatus OnUpdate()
	{
		if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
		{
			return TaskStatus.COMPLETED;
		}

		return TaskStatus.RUNNING;
	}
}
