using UnityEngine;

/// <summary>
/// Main script for third-person movement of the character in the game.
/// Ensure the object with this script (the player) has the Player tag and the Character Controller component.
/// </summary>
public class ThirdPersonController : MonoBehaviour
{
	[Tooltip("Speed ​​at which the character moves. It is not affected by gravity or jumping.")]
	public float velocity = 5f;

	[Tooltip("This value is added to the speed value while the character is sprinting.")]
	public float sprintAddition = 3.5f;

	[Tooltip("The higher the value, the higher the character will jump.")]
	public float jumpForce = 18f;

	[Tooltip("Stay in the air. The higher the value, the longer the character floats before falling.")]
	public float jumpTime = 0.85f;

	[Space]
	[Tooltip("Force that pulls the player down. Changing this value affects all movement, jumping, and falling.")]
	public float gravity = 9.8f;

	// Player states
	private float jumpElapsedTime = 0f;
	private bool isJumping = false;
	private bool isSprinting = false;
	private bool isCrouching = false;

	// Inputs
	private float inputHorizontal;
	private float inputVertical;
	private bool inputJump;
	private bool inputCrouch;
	private bool inputSprint;

	private Animator animator;
	private CharacterController cc;

	void Start()
	{
		cc = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();

		// Warning if the Animator component is missing
		if (animator == null)
		{
			Debug.LogWarning("Animator component is missing. Without it, the animations won't work.");
		}
	}

	void Update()
	{
		// Input handling
		inputHorizontal = Input.GetAxis("Horizontal");
		inputVertical = Input.GetAxis("Vertical");
		inputJump = Input.GetButtonDown("Jump");
		inputSprint = Input.GetButton("Fire3"); // Typically Left Shift for sprinting
		inputCrouch = Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.JoystickButton1);

		// Toggle crouch state
		if (inputCrouch)
		{
			isCrouching = !isCrouching;
		}

		// Animation handling
		if (cc.isGrounded && animator != null)
		{
			// Update crouch and run animations
			animator.SetBool("crouch", isCrouching);

			float minimumSpeed = 0.9f;
			animator.SetBool("run", cc.velocity.magnitude > minimumSpeed);

			// Sprinting animation
			isSprinting = cc.velocity.magnitude > minimumSpeed && inputSprint;
			animator.SetBool("sprint", isSprinting);
		}

		// Jump animation
		if (animator != null)
		{
			animator.SetBool("air", !cc.isGrounded);
		}

		// Handle jump initiation
		if (inputJump && cc.isGrounded)
		{
			isJumping = true;
		}

		HeadHittingDetect(); // Handle head collision during jumps
	}

	void FixedUpdate()
	{
		// Determine sprint or crouch speed modifiers
		float velocityAddition = 0f;
		if (isSprinting)
		{
			velocityAddition = sprintAddition;
		}
		if (isCrouching)
		{
			velocityAddition = -(velocity * 0.5f); // Reduce speed by 50% when crouching
		}

		// Movement input and directions
		float directionX = inputHorizontal * (velocity + velocityAddition) * Time.deltaTime;
		float directionZ = inputVertical * (velocity + velocityAddition) * Time.deltaTime;
		float directionY = 0f;

		// Handle jumping
		if (isJumping)
		{
			// Smooth jump ascent
			directionY = Mathf.SmoothStep(jumpForce, jumpForce * 0.3f, jumpElapsedTime / jumpTime) * Time.deltaTime;

			// Track jump duration
			jumpElapsedTime += Time.deltaTime;

			// End jump after the defined time
			if (jumpElapsedTime >= jumpTime)
			{
				isJumping = false;
				jumpElapsedTime = 0f;
			}
		}
		else
		{
			// Apply gravity when not jumping
			directionY -= gravity * Time.deltaTime;

			// Prevent downward velocity from becoming too large
			if (directionY < -gravity)
			{
				directionY = -gravity;
			}
		}

		// Calculate movement directions relative to camera
		Vector3 forward = Camera.main.transform.forward;
		Vector3 right = Camera.main.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize();
		right.Normalize();

		Vector3 forwardMovement = forward * directionZ;
		Vector3 rightMovement = right * directionX;
		Vector3 verticalMovement = Vector3.up * directionY;

		// Combine movement vectors
		Vector3 movement = verticalMovement + forwardMovement + rightMovement;

		// Apply movement to the Character Controller
		cc.Move(movement);

		// Rotate the player to face movement direction
		if (directionX != 0 || directionZ != 0)
		{
			float targetAngle = Mathf.Atan2(forwardMovement.x + rightMovement.x, forwardMovement.z + rightMovement.z) * Mathf.Rad2Deg;
			Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f);
		}
	}

	// Detect head collisions during jumps and stop jumping if collision occurs
	void HeadHittingDetect()
	{
		float headHitDistance = 1.1f;
		Vector3 ccCenter = transform.TransformPoint(cc.center);
		float hitCalc = cc.height / 2f * headHitDistance;

		if (Physics.Raycast(ccCenter, Vector3.up, hitCalc))
		{
			jumpElapsedTime = 0f;
			isJumping = false;
		}
	}
}
