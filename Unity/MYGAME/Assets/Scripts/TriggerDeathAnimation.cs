using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using Pada1.BBCore.Framework;

[Action("CustomActions/TriggerDeathAnimation")]
public class TriggerDeathAnimation : BasePrimitiveAction
{
	[InParam("vempire")]
	public Animator animator;

	public override TaskStatus OnUpdate()
	{
		animator.SetTrigger("Die");
		return TaskStatus.COMPLETED;
	}
}
