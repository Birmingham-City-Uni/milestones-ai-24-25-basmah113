using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
	public GameObject player; 
	public GameObject powerUpPrefab; 
	public Transform[] spawnPoints; 

	public float healthIncreaseAmount = 20f; 
	public float respawnTime = 5f; 
	public float activeDuration = 20f; 
	public float rotationSpeed = 100f; 

	private GameObject currentPowerUp; 
	private Coroutine activePowerUpTimer; 

	public AudioClip powerUpCollectSound; 
	private AudioSource audioSource; 

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		if (audioSource == null)
		{
			Debug.LogError("AudioSource component is missing! Please add one to the PowerUpManager.");
		}

		SpawnPowerUp();
	}

	private void SpawnPowerUp()
	{
		if (currentPowerUp != null)
		{
			Debug.Log("Destroying existing power-up instance before spawning a new one.");
			Destroy(currentPowerUp);
		}

		if (powerUpPrefab == null)
		{
			Debug.LogError("PowerUpPrefab is null! Please assign a valid prefab in the Inspector.");
			return;
		}

		if (spawnPoints.Length == 0)
		{
			Debug.LogError("No spawn points assigned! Please add spawn points in the Inspector.");
			return;
		}

		Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		currentPowerUp = Instantiate(powerUpPrefab, spawnPoint.position, Quaternion.identity);

		//Debug.Log($"Spawned power-up at {spawnPoint.position}");

		AddRotationEffect(currentPowerUp);
	}


	private void AddRotationEffect(GameObject powerUp)
	{
		if (powerUp.GetComponent<PowerUpRotator>() == null)
		{
			powerUp.AddComponent<PowerUpRotator>().rotationSpeed = rotationSpeed;
		}
	}

	void Update()
	{
		if (currentPowerUp != null && Vector3.Distance(currentPowerUp.transform.position, player.transform.position) < 1.5f)
		{
			HealthManager healthManager = player.GetComponent<HealthManager>();
			if (healthManager != null)
			{
				healthManager.IncreaseHealth(healthIncreaseAmount);
				Debug.Log("Player collected the power-up. Health increased.");
			}

			if (powerUpCollectSound != null && audioSource != null)
			{
				audioSource.PlayOneShot(powerUpCollectSound);
			}

			Destroy(currentPowerUp);
			currentPowerUp = null; 

			Invoke(nameof(SpawnPowerUp), respawnTime);
		}
	}

	private IEnumerator RemovePowerUpAfterTime()
	{
		Debug.Log("Power-up will expire in " + activeDuration + " seconds.");
		yield return new WaitForSeconds(activeDuration);

		if (currentPowerUp != null)
		{
			Debug.Log("Power-up expired.");
			Destroy(currentPowerUp);
			currentPowerUp = null; 

			Invoke(nameof(SpawnPowerUp), respawnTime);
		}
	}
}
