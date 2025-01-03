using Pada1.BBCore; // Ensure this matches your Behavior Bricks namespace
using Pada1.BBCore.Tasks; // For tasks and conditions
using Pada1.BBCore.Framework; // For the framework classes
using UnityEngine; // For Vector3 and Transform

[Condition("MyConditions/IsTargetFar")]
public class IsTargetFar : ConditionBase
{
	[InParam("target")] // Target GameObject to evaluate
	public GameObject target;

	[InParam("self")] // The GameObject this script is attached to
	public GameObject self;

	[InParam("distanceThreshold")] // Distance threshold to evaluate
	public float distanceThreshold;

	public override bool Check()
	{
		if (target == null || self == null)
		{
			Debug.LogWarning("Target or self is not assigned in IsTargetFar condition.");
			return false;
		}

		// Calculate the distance between the self and the target
		float distance = Vector3.Distance(self.transform.position, target.transform.position);

		// Return true if the target is farther than the threshold
		return distance > distanceThreshold;
	}
}
