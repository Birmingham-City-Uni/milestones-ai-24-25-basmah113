using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using BBUnity.Actions;

[Action("Custom/MoveToTarget")]
public class MoveToTarget : GOAction // Ensure GOAction or BasePrimitiveAction is used
{
	[InParam("Player")]
	public GameObject target;

	[InParam("speed")]
	public float speed;

	public override TaskStatus OnUpdate()
	{
		if (target == null)
		{
			Debug.LogError("Target is null in MoveToTarget action.");
			return TaskStatus.FAILED;
		}

		// Move towards the target
		Vector3 direction = (target.transform.position - this.gameObject.transform.position).normalized;
		this.gameObject.transform.position += direction * speed * Time.deltaTime;

		// Check if reached target
		if (Vector3.Distance(this.gameObject.transform.position, target.transform.position) < 0.1f)
		{
			return TaskStatus.COMPLETED;
		}

		return TaskStatus.RUNNING;
	}
}
