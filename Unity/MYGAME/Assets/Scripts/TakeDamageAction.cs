using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;
using Pada1.BBCore;

[Action("Custom/TakeDamageAction")]
public class TakeDamageAction : BasePrimitiveAction
{
	[InParam("damage")]
	public float damage;

	[InParam("healthManager")]
	public HealthManager healthManager;

	public override void OnStart()
	{
		if (healthManager != null)
		{
			healthManager.TakeDamage(damage);
		}
	}

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.COMPLETED;
	}
}
