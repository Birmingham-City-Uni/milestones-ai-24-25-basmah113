using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using BBUnity.Actions;

[Condition("Custom/IsTargetClose")]
public class IsTargetClose : GOAction
{
	[InParam("Player")]
	public GameObject target;

	[InParam("distance")]
	public float distance;

	public override TaskStatus OnUpdate()
	{
		if (target == null)
		{
			Debug.LogError("Target is null in IsTargetClose condition.");
			return TaskStatus.FAILED;
		}

		// Check if the target is within distance
		float currentDistance = Vector3.Distance(this.gameObject.transform.position, target.transform.position);
		return currentDistance <= distance ? TaskStatus.COMPLETED : TaskStatus.FAILED;
	}
}
