using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipActions : MonoBehaviour {

	private bool belowDeckArea = false;

	void Start() {
	}

	private void OnTriggerEnter(Collider other) {
		// Debug.Log("ASHHK");

		if (other.tag == "BelowDeck") {
			belowDeckArea = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "BelowDeck") {
			belowDeckArea = false;
		}
	}

	public void Update() {
		if (belowDeckArea && Input.GetKey("i")) {
				SceneManager.LoadScene("BelowDeck");
		}
	}
}