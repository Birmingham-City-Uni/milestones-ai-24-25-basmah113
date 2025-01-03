using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using Pada1.BBCore;
using UnityEngine;

[Action("Custom/AttackAction")]
public class AttackAction : BasePrimitiveAction
{
	[InParam("player")]
	public Transform player;

	[InParam("healthManager")]
	public HealthManager playerHealth;

	[InParam("damage")]
	public float damage;

	public override void OnStart()
	{
		if (playerHealth != null)
		{
			playerHealth.TakeDamage(damage);
		}
	}

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.COMPLETED;
	}
}
