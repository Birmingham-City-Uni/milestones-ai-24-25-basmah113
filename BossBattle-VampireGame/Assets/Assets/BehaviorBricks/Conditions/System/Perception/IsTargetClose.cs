﻿using Pada1.BBCore;
using UnityEngine;

namespace BBUnity.Conditions
{
	[Condition("Perception/IsTargetClose")]
	[Help("Checks whether a target is close depending on a given distance")]
	public class IsTargetClose : GOCondition
	{
		[InParam("Player")]
		[Help("Target to check the distance")]
		public GameObject target;

		[InParam("closeDistance")]
		[Help("The maximum distance to consider that the target is close")]
		public float closeDistance;

		public override bool Check()
		{
			if (target == null)
			{
				Debug.LogError("Target is null in IsTargetClose condition.");
				return false;
			}

			return (gameObject.transform.position - target.transform.position).sqrMagnitude < closeDistance * closeDistance;
		}
	}
}
