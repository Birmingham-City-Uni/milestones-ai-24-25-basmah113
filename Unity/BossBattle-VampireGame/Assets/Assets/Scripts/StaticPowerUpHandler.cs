using UnityEngine;

public class StaticPowerUpHandler : MonoBehaviour
{
	public float healthIncreaseAmount = 20f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			HealthManager healthManager = other.GetComponent<HealthManager>();
			if (healthManager != null)
			{
				healthManager.IncreaseHealth(healthIncreaseAmount);
				Debug.Log("Static power-up collected. Health increased.");
			}

			
			Destroy(gameObject); 
		}
	}
}
