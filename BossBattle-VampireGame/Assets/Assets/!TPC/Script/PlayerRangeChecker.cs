using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeChecker : MonoBehaviour
{
    public Transform player;
    public List<Transform> enemies;
    public float detectionRange = 10f; 
    public bool isInRange;
    //[HideInInspector]
    public EnemyController _ec;
    void Update()
    {
        CheckEnemiesInRange();
    }

	void CheckEnemiesInRange()
	{
		foreach (Transform enemy in enemies)
		{
			if (enemy == null) continue; 

			float distance = Vector3.Distance(player.position, enemy.position);

			if (distance <= detectionRange)
			{
				isInRange = true;
				_ec = enemy.gameObject.GetComponent<EnemyController>();
				Debug.Log($"Enemy {enemy.name} is within range!");
				return; 
			}
		}

		isInRange = false;
		_ec = null;
	}

}
