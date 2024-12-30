using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
	// Movement speeds
	public float walkSpeed = 2f;
	public float runSpeed = 5f;
	public float jumpForce = 5f;
	public float gravity = 9.8f;

	// Components
	private NavMeshAgent agent;
	private Animator animator;

	// FSM Enum
	public enum PlayerState
	{
		Idle,
		Walking,
		Running,
		Jumping
	}

	private PlayerState currentState = PlayerState.Idle;

	// Jumping variables
	private bool isJumping = false;
	private float verticalVelocity = 0f;

	void Start()
	{
		// Initialize components
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();

		if (agent == null)
		{
			Debug.LogError("NavMeshAgent component is missing!");
		}
		if (animator == null)
		{
			Debug.LogError("Animator component is missing!");
		}

		// Prevent NavMeshAgent from auto-rotating
		agent.updateRotation = false;
	}

	void Update()
	{
		// Handle movement and state
		if (!isJumping)
		{
			HandleMovement();
		}

		// Handle jumping
		if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
		{
			StartJump();
		}

		// Apply gravity and update vertical velocity if jumping
		if (isJumping)
		{
			ApplyGravity();
		}

		// Update the FSM state in debug
		Debug.Log("Current State: " + currentState);
	}

	private void HandleMovement()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

		if (direction.magnitude >= 0.1f)
		{
			// Determine speed
			float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

			// Move the agent
			agent.Move(direction * speed * Time.deltaTime);

			// Rotate the player towards the direction of movement
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

			// FSM Transition: Walking or Running
			currentState = Input.GetKey(KeyCode.LeftShift) ? PlayerState.Running : PlayerState.Walking;

			// Update animator parameters
			animator.SetFloat("speed", speed);
		}
		else
		{
			// FSM Transition: Idle
			currentState = PlayerState.Idle;
			animator.SetFloat("speed", 0);
		}
	}

	private void StartJump()
	{
		// Set jumping state
		isJumping = true;
		currentState = PlayerState.Jumping;

		// Disable NavMeshAgent while jumping
		agent.enabled = false;

		// Trigger jump animation
		animator.SetTrigger("jump");

		// Apply initial jump force
		verticalVelocity = jumpForce;
	}

	private void ApplyGravity()
	{
		verticalVelocity -= gravity * Time.deltaTime;

		Vector3 jumpMovement = new Vector3(0, verticalVelocity * Time.deltaTime, 0);
		transform.Translate(jumpMovement, Space.World);

		// Check if player has landed
		if (transform.position.y <= 0.1f)
		{
			// Reset jumping state
			isJumping = false;
			currentState = PlayerState.Idle;

			// Re-enable NavMeshAgent
			agent.enabled = true;

			// Reset vertical position
			Vector3 position = transform.position;
			position.y = 0;
			transform.position = position;
		}
	}
}