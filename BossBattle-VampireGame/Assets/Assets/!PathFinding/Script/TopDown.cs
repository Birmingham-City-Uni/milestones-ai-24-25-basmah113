using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDown : MonoBehaviour
{
	public float moveSpeed = 5f; // Speed of movement
	public float rotationSpeed = 720f; // Speed of rotation (degrees per second)

	private CharacterController characterController;
	private Vector3 moveDirection;

	public float gravity = -9.81f;
	private float verticalVelocity;
	public float rayLength = 1f; // Distance to check below the player
	public LayerMask groundLayer; // Layer to detect specific objects (optional)
	public tile playerPos;
	public Animator _anim;

	void Start()
	{
		// Get the CharacterController component
		characterController = GetComponent<CharacterController>();
	}

	void Update()
	{
		// Get input for movement
		float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
		float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow

		// Create a movement direction vector
		moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

		if (characterController.isGrounded)
		{
			verticalVelocity = 0f; // Reset gravity when grounded
		}
		else
		{
			verticalVelocity += gravity * Time.deltaTime;
		}

		Vector3 gravityEffect = new Vector3(0, verticalVelocity, 0);

		if (moveDirection.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
			Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

			characterController.Move((moveDirection * moveSpeed + gravityEffect) * Time.deltaTime);
		}
		else
		{
			// Apply gravity when stationary
			characterController.Move(gravityEffect * Time.deltaTime);
		}

		AnimateMovement();
	}

	private void FixedUpdate()
	{
		// Cast a ray downward from the player's position
		if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, rayLength, groundLayer))
		{
			playerPos = hit.collider.gameObject.GetComponent<tile>();
		}
		else
		{
			//Debug.Log("No object below the player.");
		}
	}

	private void AnimateMovement()
	{
		float directionX = Vector3.Dot(moveDirection.normalized, transform.right);
		float directionZ = Vector3.Dot(moveDirection.normalized, transform.forward);

		_anim.SetFloat("directionX", directionX, 0.1f, Time.deltaTime);
		_anim.SetFloat("directionZ", directionZ, 0.1f, Time.deltaTime);
	}
}
