using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
	public GridManager _GM;
	float _time;

	private void Update()
	{
		if (_GM.isMove == false)
		{
			_time += Time.unscaledDeltaTime;
			if (_time > 3)
			{
				_GM.isMove = true;
			}
		}
	}
}
