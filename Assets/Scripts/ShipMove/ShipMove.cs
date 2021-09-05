using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipMove : MonoBehaviour {

	private float speedOfShip; //need to also change PlayerMovement script
	private float turningSpeed;

	void Start() {
		// transform.position = new Vector3(1,1,0);
	}

	void Update() {
		speedOfShip = Globals.shipSpeed;

		if (this.tag == "PirateShip") {
			transform.position += new Vector3(0, 0, 1 * Time.deltaTime * (speedOfShip - 0.8f));
		} else {
			transform.position += new Vector3(0, 0, 1 * Time.deltaTime * speedOfShip);
		}

		if (Input.GetKey("l")) {
			Debug.Log("Entering loop with L");
			transform.Rotate(Vector3.up * 60 * Time.deltaTime);
		}
		if (Input.GetKey("r")) {
			transform.Rotate(Vector3.up * 60 * Time.deltaTime);
		}
 }
}
		// Debug.Log("Ship speed" + speedOfShip);
		// Debug.Log(speedOfShip);

		// transform.position += Vector3.forward * Time.deltaTime * speedOfShip;
		// Debug.Log(speedOfShip);

		// if (Input.GetKeyUp("r")) {
		// 	transform.Rotate(-90, transform.localRotation.eulerAngles.y + 1 * Time.deltaTime, 0);
		// }
		// if (Input.GetKeyUp("l")) {
		// 	transform.Rotate(-90, transform.localRotation.eulerAngles.y - 1 * Time.deltaTime, 0);
		// }