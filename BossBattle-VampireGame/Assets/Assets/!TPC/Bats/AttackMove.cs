using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMove : MonoBehaviour
{
    public float speed;
    public Transform _player;

    private void OnEnable()
    {
        Destroy(this.gameObject, 2f);
    }

    private void Update()
    {
        // Calculate the direction towards the player
        Vector3 direction = (_player.position - transform.position).normalized;

        // Move the object in the direction of the player
        transform.position += direction * speed * Time.deltaTime;

        this.transform.LookAt(_player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _player.GetComponent<HealthManager>().TakeDamage(0.1f);
            Destroy(this.gameObject);
        }
    }

}
