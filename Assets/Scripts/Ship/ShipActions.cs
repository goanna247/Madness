using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipActions : MonoBehaviour {

	private bool belowDeckArea = false;
	private bool steeringArea = false;
	private bool sailArea = false;

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
		if (belowDeckArea && Input.GetKey("i")) {
			SceneManager.LoadScene("BelowDeck");
		}

		if (sailArea && Input.GetKey("+")) {
			//vroom vroom bitch
		} else if (sailArea && Input.GetKey("-")) {
			//go slower 
		}

		if (steeringArea && Input.GetKey("l")) {
			//go left
		} else if (steeringArea && Input.GetKey("r")) {
			//go right 
		}
	}
}