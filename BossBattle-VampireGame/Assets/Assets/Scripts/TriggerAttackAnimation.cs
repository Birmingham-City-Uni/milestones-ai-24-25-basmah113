using Pada1.BBCore.Tasks;
using Pada1.BBCore;
using UnityEngine;
using Pada1.BBCore.Framework;

[Action("Custom/TriggerAttackAnimation")]
public class TriggerAttackAnimation : BasePrimitiveAction
{
	[InParam("vempire")]
	public Animator animator;

	public override void OnStart()
	{
		animator.SetTrigger("Attack");
	}
}
