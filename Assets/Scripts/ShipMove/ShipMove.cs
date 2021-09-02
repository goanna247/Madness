using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipMove : MonoBehaviour {
	
	Rigidbody shipRigidBody;

	[SerializeField]
	private Transform player, ship;
	private Camera playerCam;

	[SerializeField]
	float speed;


	void Start() {
		shipRigidBody = GetComponent<Rigidbody>();
		speed = 1.0f;
	}

	void Update() {
		// player.Translate(Vector3.down * Time.deltaTime * speed);
		// ship.Translate(Vector3.down * Time.deltaTime * speed);
		// playerCam.transform.position = new (Vector3.down * Time.deltaTime * speed);

	}
}