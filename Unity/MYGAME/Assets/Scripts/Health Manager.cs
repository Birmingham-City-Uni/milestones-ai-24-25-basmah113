using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
	public float maxHealth = 100f;
	private float currentHealth;
	public Slider healthSlider;

	private Animator animator;
	private bool isDead = false;

	public bool isPlayer;

	void Start()
	{
		currentHealth = maxHealth;

		if (healthSlider != null)
		{
			healthSlider.maxValue = maxHealth;
			healthSlider.value = currentHealth;
		}

		animator = GetComponentInChildren<Animator>();
	}

	public void TakeDamage(float damage)
	{
		if (isDead) return;

		currentHealth -= damage;

		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

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
