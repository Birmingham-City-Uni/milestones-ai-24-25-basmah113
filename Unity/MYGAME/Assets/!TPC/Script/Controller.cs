using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public PlayerRangeChecker _PRC;
    private CharacterController characterController;
    [NonSerialized]
    public Animator characterAnimator;

    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float jumpSpeed = 5f;
    [SerializeField]
    private float gravity = 10f;

    private Vector3 direction = Vector3.zero;

    private float inputX = 0;
    private float inputZ = 0;

    //[NonSerialized]
    public bool canMove = true;

    [NonSerialized]
    public GameObject availableItem = null;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterAnimator = GetComponent<Animator>();

    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            inputX = Input.GetAxis("Vertical");
            inputZ = Input.GetAxis("Horizontal");
            direction = (forward * inputX * movementSpeed) + (right * inputZ * movementSpeed);

            if (Input.GetKeyDown(KeyCode.Space) && canMove)
            {
                characterAnimator.SetBool("isJumping", true);
                direction.y = jumpSpeed;
            }
        }

        direction.y -= gravity * Time.deltaTime;

        if (canMove)
        {
            characterController.Move(direction * Time.deltaTime);
            AnimateMovement();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Attacking();
        }

    }

    private void AnimateMovement()
    {
        float directionX = Vector3.Dot(direction.normalized, transform.right);
        float directionZ = Vector3.Dot(direction.normalized, transform.forward);

        characterAnimator.SetFloat("directionX", directionX, 0.1f, Time.deltaTime);
        characterAnimator.SetFloat("directionZ", directionZ, 0.1f, Time.deltaTime);
    }

    void Attacking()
    {
        //canMove = false;
        characterAnimator.SetBool("isAttacking", true);
    }

	public void PunchDamage()
	{
		if (_PRC.isInRange && _PRC._ec != null)
		{
			_PRC._ec.GetHit(10); 
			Debug.Log($"Enemy {_PRC._ec.name} hit, dealt 10 damage.");
		}
	}

}
