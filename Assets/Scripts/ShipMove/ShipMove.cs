using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipMove : MonoBehaviour {

	private float speedOfShip = 1f; //need to also change PlayerMovement script

	void Start() {
		transform.position = new Vector3(1,1,0);
	}

	void Update() {
		transform.position += new Vector3(0, 0, 1 * Time.deltaTime);
	}
}