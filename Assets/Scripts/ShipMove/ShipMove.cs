using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ShipMove : MonoBehaviour {

	private float speedOfShip; //need to also change PlayerMovement script
	private float turningSpeed;

	void Start() {
		// transform.position = new Vector3(1,1,0);
	}

	void Update() {
		speedOfShip = Globals.shipSpeed;

		transform.position += transform.forward * Time.deltaTime * speedOfShip;

		if (Input.GetKey("l")) {
			Debug.Log("Entering loop with L");
			transform.Rotate(Vector3.down * 60 * Time.deltaTime);
		}
		if (Input.GetKey("r")) {
			transform.Rotate(Vector3.up * 60 * Time.deltaTime);
		}
 }

 void OnTriggerEnter(Collider other) {
	 if (other.tag == "PirateShip") {
		 SceneManager.LoadScene("PirateFight");
	 }
 }
}