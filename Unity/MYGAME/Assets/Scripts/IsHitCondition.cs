using Pada1.BBCore; // Ensure this namespace matches your Behavior Bricks package
using Pada1.BBCore.Tasks; // For task-specific attributes
using Pada1.BBCore.Framework; // For BehaviorNode and related classes

[Condition("MyConditions/IsHitCondition")]
public class IsHitCondition : ConditionBase
{
	[InParam("isHit")]
	public bool isHit; // This binds the Blackboard parameter to the condition

	public override bool Check()
	{
		// Returns true if isHit is true
		return isHit;
	}
}
