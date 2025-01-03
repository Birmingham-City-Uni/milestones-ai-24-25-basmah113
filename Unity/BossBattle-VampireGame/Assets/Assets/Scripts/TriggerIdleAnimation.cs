using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using Pada1.BBCore.Framework;

[Action("Custom/TriggerIdleAnimation")]
public class TriggerIdleAnimation : BasePrimitiveAction
{
	[InParam("vempire")]
	public Animator animator;

	public override void OnStart()
	{
		animator.SetTrigger("Idle");
	}
}
