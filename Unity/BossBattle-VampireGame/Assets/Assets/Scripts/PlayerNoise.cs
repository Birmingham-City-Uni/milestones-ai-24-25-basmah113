using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{
	public float noiseRadius = 20f;
	public LayerMask enemyLayer;

	public void GenerateNoise()
	{
		Debug.Log($"GenerateNoise() called from {name} at position {transform.position}");

		Collider[] hitColliders = Physics.OverlapSphere(transform.position, noiseRadius, enemyLayer);
		Debug.Log($"Noise generated. Detected {hitColliders.Length} objects in noise radius.");

		foreach (var hitCollider in hitColliders)
		{
			EnemyController enemy = hitCollider.GetComponent<EnemyController>();
			if (enemy != null)
			{
				enemy.HeardNoise(transform.position);
				Debug.Log($"Notified enemy: {enemy.name}");
			}
			else
			{
				Debug.Log($"Detected object {hitCollider.name} does not have an EnemyController.");
			}
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, noiseRadius);
	}
}
