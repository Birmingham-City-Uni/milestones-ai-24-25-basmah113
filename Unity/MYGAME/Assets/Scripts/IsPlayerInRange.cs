using UnityEngine;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using Pada1.BBCore;

[Condition("Custom/IsPlayerInRange")]
public class IsPlayerInRange : ConditionBase
{
	[InParam("player")]
	public Transform player;

	[InParam("enemy")]
	public Transform enemy;

	[InParam("range")]
	public float range;

	public override bool Check()
	{
		if (player == null || enemy == null)
		{
			Debug.LogError("IsPlayerInRange: Player or Enemy Transform is null.");
			return false;
		}

		float distance = Vector3.Distance(player.position, enemy.position);
		return distance <= range; // Returns true if within range
	}
}
