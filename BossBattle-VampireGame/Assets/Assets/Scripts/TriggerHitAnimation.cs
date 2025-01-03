using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Tasks;
using Pada1.BBCore.Framework;

[Action("Animation/TriggerHitAnimation")]
public class TriggerHitAnimation : BasePrimitiveAction
{
	[InParam("vempire")]
	public Animator animator; // The Animator component of the vampire.

	public override void OnStart()
	{
		if (animator != null)
		{
			animator.SetTrigger("TakeHit");
		}
		else
		{
			Debug.LogError("Animator is not assigned!");
		}
	}

}
