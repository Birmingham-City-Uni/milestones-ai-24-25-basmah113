using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthManager : MonoBehaviour
{
	public float maxHealth = 100f;
	private float currentHealth;
	public Slider healthSlider;

	private Animator animator;
	private bool isDead = false;

	public bool isPlayer;
	public AudioSource TakeHit_audio;
	[HideInInspector]
	public GameObject img_damage;

	int int_recalling;

	void Start()
	{
		currentHealth = maxHealth;
		if(isPlayer)
        {
			img_damage.SetActive(false);
		}
		
		if (healthSlider != null)
		{
			healthSlider.maxValue = maxHealth;
			healthSlider.value = currentHealth;
		}

		animator = GetComponentInChildren<Animator>();
	}

	public float GetHealth()
	{
		return currentHealth;
	}

	IEnumerator Ie_TakeDamage()
    {
		img_damage.SetActive(true);
		TakeHit_audio.Play();
		yield return new WaitForSecondsRealtime(0.2f);
		img_damage.SetActive(false);
    }
	
	public void TakeDamage(float damage)
	{
		if (isDead) return;

		currentHealth -= damage;
	
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
		if(isPlayer)
        {
			StartCoroutine(Ie_TakeDamage());
		}
	
		if(isPlayer == false)
        {
			TakeHit_audio.Play();
			if(currentHealth < 50)
            {
				if(int_recalling<4)
                {
					int_recalling++;
					this.transform.GetComponent<EnemyController>()._isHeathReduce = true;
				}

				
            }
        }

		if (healthSlider != null)
		{
			healthSlider.value = currentHealth;
		}

		if (currentHealth <= 0 && !isDead)
		{
			HandleDeath();
		}
	}

	private void HandleDeath()
	{
		isDead = true;

		if (animator != null)
		{
			animator.SetTrigger("isDead");
		}

		if (isPlayer)
		{
			GetComponent<Controller>().enabled = false;
			GetComponent<SwordHandler>().enabled = false;

			Invoke("PlayerDied", 2f); 
		}
		else
		{
			GetComponent<EnemyController>().enabled = false;
			GetComponent<BatSpawner>().isSpawnStart = true;
			Invoke("EnemyDied", 2f); 
		}
	}

	public void IncreaseHealth(float amount)
	{
		if (isDead) return;

		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

		if (healthSlider != null)
		{
			healthSlider.value = currentHealth;
		}
	}

	private void PlayerDied()
	{
		Debug.Log("Player Died");
		FindObjectOfType<GameUIManager>().ShowGameOver();
	}

	private void EnemyDied()
	{
		Debug.Log("Enemy Defeated");
		FindObjectOfType<GameUIManager>().ShowVictory();
	}


}
