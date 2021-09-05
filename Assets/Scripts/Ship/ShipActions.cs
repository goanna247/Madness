using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShipActions : MonoBehaviour {

	private bool belowDeckArea = false;
	private bool steeringArea = false;
	private bool sailArea = false;

	float shipSpeed = Globals.shipSpeed;

	

	void Start() {}

	private void OnTriggerEnter(Collider other) {
		// Debug.Log("ASHHK");

		if (other.tag == "BelowDeck") {
			belowDeckArea = true;
		} else if (other.tag == "Steer") {
			steeringArea = true;
		} else if (other.tag == "SailAdjuster") {
			sailArea = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "BelowDeck") {
			belowDeckArea = false;
		} else if (other.tag == "Steer") {
			steeringArea = false;
		} else if (other.tag == "SailAdjuster") {
			sailArea = false;
		}
	}

	public void Update() {
		Globals.shipSpeed = shipSpeed;

		if (belowDeckArea && Input.GetKey("i")) {
			SceneManager.LoadScene("BelowDeck");
		}

		if (sailArea && Input.GetKeyUp("9")) {
			shipSpeed = shipSpeed + 0.5f; //vroom vroom bitch
			// Debug.Log("plus speed");
		} else if (sailArea && Input.GetKeyUp("0")) {
			shipSpeed = shipSpeed - 0.5f; //go slower 
			// Debug.Log("minus speed");
		}

		// Debug.Log(shipSpeed);

		if (steeringArea && Input.GetKey("l")) {
			//go left
			Debug.Log("Left");
		} else if (steeringArea && Input.GetKey("r")) {
			//go right 
			Debug.Log("Right");
		}
	}
}