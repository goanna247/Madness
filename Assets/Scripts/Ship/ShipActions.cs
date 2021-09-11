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

	[SerializeField] private GameObject ship;

	

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

		if (Globals.shipSpeed <= 10f) {
			if (Input.GetKeyUp("1")) {
				Globals.shipSpeed += 0.5f; //vroom vroom bitch
			}
		}
		if (Globals.shipSpeed > 0f) {
			if (Input.GetKeyUp("0")) {
				shipSpeed = shipSpeed - 0.5f; //go slower 
			}
		}


		//47 88! 47 88!
		if (Input.GetKey("4")) {
			if (Input.GetKey("7")) {
				if (Input.GetKey("8")) {
						ship.GetComponent<Renderer>().material.color = new Color(1f, 0.3f, 1f, 1f);
				}
			}
		}
	}
}