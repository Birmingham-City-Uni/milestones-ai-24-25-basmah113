using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeChecker : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public List<Transform> enemies; // List of enemy transforms
    public float detectionRange = 10f; // Range within which enemies are detected
    public bool isInRange;
    [HideInInspector]
    public EnemyController _ec;
    void Update()
    {
        CheckEnemiesInRange();
    }

    void CheckEnemiesInRange()
    {
        foreach (Transform enemy in enemies)
        {
            if (enemy == null) continue; // Skip if the enemy has been destroyed

            float distance = Vector3.Distance(player.position, enemy.position);

            if (distance <= detectionRange)
            {
                isInRange = true;
                _ec = enemy.gameObject.GetComponent<EnemyController>();
                Debug.Log($"Enemy {enemy.name} is within range!");
            }
            else
            {
                isInRange = false;
                _ec = null;
                Debug.Log($"Enemy {enemy.name} is out of range.");
            }
        }
    }
}
