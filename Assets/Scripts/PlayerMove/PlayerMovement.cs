using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private CharacterController characterController;

	private Vector3 moveDirection; 

	public float speed = 3f;
	private float gravity = 20f;

	public float jumpForce = 5f;
	private float verticalVelocity;

	private float speedOfShip = Globals.shipSpeed;

	void Awake() {
		characterController = GetComponent<CharacterController>();
	}

	void Update() {
		// speedOfShip 
		MoveThePlayer();
		characterController.Move(Vector3.forward * Time.deltaTime * (speedOfShip/2));

		// Debug.Log(s		// Debug.Log("Player speed =" + speedOfShip);peedOfShip);
	}

	void MoveThePlayer() {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
		

		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed * Time.deltaTime;

		ApplyGravity();

		characterController.Move(moveDirection);

	}

	void ApplyGravity() {
		verticalVelocity -= gravity * Time.deltaTime;

		PlayerJump();

		moveDirection.y = verticalVelocity * Time.deltaTime;
	}

	void PlayerJump() {
		if (characterController.isGrounded && Input.GetKeyDown (KeyCode.Space)) {
			verticalVelocity = jumpForce;
		}
	}
}