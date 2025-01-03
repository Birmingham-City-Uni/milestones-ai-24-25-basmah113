using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using Pada1.BBCore.Framework;

[Condition("CustomConditions/IsDeadCondition")]
public class IsDeadCondition : ConditionBase
{
	[InParam("isDead")]
	public bool isDead;

	public override bool Check()
	{
		return isDead;
	}
}
