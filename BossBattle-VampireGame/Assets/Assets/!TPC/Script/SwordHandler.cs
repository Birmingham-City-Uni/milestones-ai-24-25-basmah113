using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHandler : MonoBehaviour
{
	public Controller _C;
	public GameObject[] _swords;
	private PlayerNoise noiseGenerator;

	void Start()
	{
		noiseGenerator = GetComponent<PlayerNoise>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.J)) // Attack input
		{
			_C._isAttack = true;
			// Switch swords for the attack animation
			_swords[0].SetActive(false);
			_swords[1].SetActive(true);

			// Trigger the sword attack
			SwordAttack();
		}

		if(Input.GetKeyUp(KeyCode.J))
        {
			_C._isAttack = false;
        }
	}

	void SwordAttack()
	{
		Debug.Log("SwordAttack triggered. Generating noise...");
		if (noiseGenerator != null)
		{
			noiseGenerator.GenerateNoise();
		}
		else
		{
			Debug.LogWarning("No PlayerNoise component found on Player!");
		}

		_C.characterAnimator.SetTrigger("SwordAttack");
		Invoke("FncReacive", 0.8f);
	}



	public void FncReacive()
	{
		_swords[0].SetActive(true);
		_swords[1].SetActive(false);
	}
}
