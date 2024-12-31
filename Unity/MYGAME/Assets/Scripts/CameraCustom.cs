using UnityEngine;

public class CameraCustom : MonoBehaviour
{
	public Transform target; // The target (usually the player) the camera will follow
	public Vector3 offset = new Vector3(0, 2, -5); // Offset from the target
	public float followSpeed = 5f; // Smoothness of camera following
	public float rotationSpeed = 100f; // Speed of rotation when moving the camera
	public bool allowRotation = true; // Allow the camera to rotate with mouse input

	private float pitch = 0f; // Vertical rotation (up/down)
	private float yaw = 0f; // Horizontal rotation (left/right)

	void Start()
	{
		if (target == null)
		{
			Debug.LogError("No target assigned for the camera to follow!");
			return;
		}

		// Initialize camera rotation based on the target's position
		transform.position = target.position + offset;
		transform.LookAt(target.position + Vector3.up * 1.5f);

		// Save initial rotation values
		Vector3 angles = transform.eulerAngles;
		yaw = angles.y;
		pitch = angles.x;
	}

	void LateUpdate()
	{
		if (target == null) return;

		// Handle camera rotation based on mouse input
		if (allowRotation && Input.GetMouseButton(1)) // Right mouse button to rotate
		{
			yaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
			pitch -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
			pitch = Mathf.Clamp(pitch, -40f, 80f); // Limit vertical rotation
		}

		// Calculate desired position and rotation
		Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
		Vector3 desiredPosition = target.position + rotation * offset;

		// Smoothly move the camera to the desired position
		transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

		// Always look at the target
		transform.LookAt(target.position + Vector3.up * 1.5f); // Adjust height slightly for better alignment
	}
}
