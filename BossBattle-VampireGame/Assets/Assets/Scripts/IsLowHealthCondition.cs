using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using Pada1.BBCore;

[Condition("Custom/IsLowHealthCondition")]
public class IsLowHealthCondition : ConditionBase
{
	[InParam("health")]
	public float health;

	[InParam("threshold")]
	public float threshold;

	public override bool Check()
	{
		return health < threshold; // Returns true if health is below the threshold
	}
}
