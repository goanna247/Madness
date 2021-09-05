using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PirateShipMove : MonoBehaviour {

	private float speedOfShip;

	void Update() {
		speedOfShip = Globals.shipSpeed;

		transform.position += new Vector3(0, 0, 1 * Time.deltaTime * (speedOfShip - 0.8f));

		// transform.Rotate(-90, 90, 0);
	}
}